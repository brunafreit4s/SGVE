﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Models;
using SGVE.Cart.Models.Context;

namespace SGVE.Cart.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public CarrinhoRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ClearCarrinho(string userId)
        {
            var venda= await _context.Vendas.FirstOrDefaultAsync(v => v.UserId == userId);

            if(venda != null)
            {
                _context.Venda_x_Produto.RemoveRange(
                    _context.Venda_x_Produto.Where(c => c.Id_Venda == venda.Id_Venda));

                _context.Vendas.Remove(venda);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<CarrinhoVO> FindCarrinhoByUserId(string userId)
        {
            Carrinho carrinho = new Carrinho();

            carrinho.venda_x_produto = _context.Venda_x_Produto
                .Where(c => c.Id_Venda == carrinho.venda_x_produto.FirstOrDefault(c => c.Venda.UserId == userId).Venda.Id_Venda)
                .Include(c => c.Produto);

            return _mapper.Map<CarrinhoVO>(carrinho);
        }

        public async Task<bool> RemoveFromCarrinho(long idVendaxProduto)
        {
            try
            {
                Venda_x_Produto vendaxproduto = await _context.Venda_x_Produto.FirstOrDefaultAsync(c => c.Id_Venda_x_Produto == idVendaxProduto);

                int total = _context.Venda_x_Produto.Where(c => c.Id_Venda == vendaxproduto.Id_Venda).Count();

                _context.Venda_x_Produto.Remove(vendaxproduto);

                if (total == 1) {
                    var vendaToRemove = await _context.Vendas.FirstOrDefaultAsync(v => v.Id_Venda == vendaxproduto.Id_Venda);
                    _context.Vendas.Remove(vendaToRemove);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<CarrinhoVO> SaveOrUpdateCarrinho(CarrinhoVO vo)
        {
            try
            {
                Carrinho carrinho = _mapper.Map<Carrinho>(vo);

                /* Verifica se o produto já existe no carrinho */
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id_Produto == vo.venda_x_produto.FirstOrDefault().Id_Produto);

                /* Se não existe salva o produto */
                if (produto == null)
                {
                    _context.Produtos.Add(carrinho.venda_x_produto.FirstOrDefault().Produto);
                    await _context.SaveChangesAsync();
                }

                var venda = await _context.Vendas.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == carrinho.venda_x_produto.FirstOrDefault().Venda.UserId);

                /* Verifica se a venda está vazia */
                if (venda == null)
                {
                    /* se for nulo, salva a venda */
                    _context.Vendas.Add(carrinho.venda_x_produto.FirstOrDefault().Venda);
                    await _context.SaveChangesAsync();

                    await AdicionaCarrinho(carrinho);
                }
                else
                {                    
                    /* se a venda não estiver vazia, apenas atualiza as informações do carrinho */
                    var vendaxproduto = await _context.Venda_x_Produto.AsNoTracking().FirstOrDefaultAsync(
                        p => p.Id_Produto == vo.venda_x_produto.FirstOrDefault().Id_Produto && 
                        p.Id_Venda == venda.Id_Venda);

                    if (vendaxproduto == null) { await AdicionaCarrinho(carrinho); } /* adiciona no carrinho (relação da venda e o produto) */
                    else
                    {
                        /* atualiza o contador e o carrinho (relação da venda e o produto) */
                        carrinho.venda_x_produto.FirstOrDefault().Produto = null; /* limpa para não gerar conflito */
                        carrinho.venda_x_produto.FirstOrDefault().Count += vendaxproduto.Count;
                        carrinho.venda_x_produto.FirstOrDefault().Id_Venda_x_Produto = vendaxproduto.Id_Venda_x_Produto;
                        carrinho.venda_x_produto.FirstOrDefault().Id_Venda = vendaxproduto.Id_Venda;
                        _context.Venda_x_Produto.Update(carrinho.venda_x_produto.FirstOrDefault());
                        await _context.SaveChangesAsync();
                    }
                }

                return _mapper.Map<CarrinhoVO>(carrinho);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task AdicionaCarrinho(Carrinho carrinho)
        {
            carrinho.venda_x_produto.FirstOrDefault().Id_Venda = carrinho.venda_x_produto.FirstOrDefault().Venda.Id_Venda;
            carrinho.venda_x_produto.FirstOrDefault().Produto = null; /* limpa para não gerar conflito */
            _context.Venda_x_Produto.Add(carrinho.venda_x_produto.FirstOrDefault());
            await _context.SaveChangesAsync();
        }
    }
}
