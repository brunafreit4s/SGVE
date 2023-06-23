using AutoMapper;
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
            var cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);

            if(cartHeader != null)
            {
                _context.CartDetails
                    .RemoveRange(_context.CartDetails
                        .Where(c => c.CartHeaderId == cartHeader.Id));

                _context.CartHeaders.Remove(cartHeader);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<CartVO> FindCarrinhoByUserId(string userId)
        {
            Models.Cart cart = new Models.Cart()
            {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId),
            };

            cart.CartDetails = _context.CartDetails
                .Where(c => c.CartHeaderId == cart.CartHeader.Id)
                .Include(c => c.Produtos);

            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveFromCarrinho(long cartDetailId)
        {
            try
            {
                CartDetail cartDetail = await _context.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailId);

                int total = _context.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetail);

                if (total == 1) {
                    var cartHeaderToRemove = await _context.CartHeaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    _context.CartHeaders.Remove(cartHeaderToRemove);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<CartVO> SaveOrUpdateCarrinho(CartVO vo)
        {
            try
            {
                Models.Cart cart = _mapper.Map<Models.Cart>(vo);

                /* Verifica se o produto já existe no carrinho */
                var product = await _context.Produtos.FirstOrDefaultAsync(p => p.Id_Produto == vo.CartDetails.FirstOrDefault().ProdutoId);

                /* Se não existe salva o produto */
                if (product == null)
                {
                    _context.Produtos.Add(cart.CartDetails.FirstOrDefault().Produtos);
                    await _context.SaveChangesAsync();
                }

                var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                    c => c.UserId == cart.CartHeader.UserId);

                /* Verifica se a venda está vazia */
                if (cartHeader == null)
                {
                    /* se for nulo, salva a venda */
                    _context.CartHeaders.Add(cart.CartHeader);
                    await _context.SaveChangesAsync();

                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    await AdicionaCarrinho(cart);
                }
                else
                {
                    /* se a venda não estiver vazia, apenas atualiza as informações do carrinho */
                    var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                        p => p.ProdutoId == cart.CartDetails.FirstOrDefault().ProdutoId &&
                        p.CartHeaderId == cartHeader.Id);

                    if (cartDetail == null) {
                        cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                        await AdicionaCarrinho(cart); 
                    }
                    else
                    {
                        /* atualiza o contador e o carrinho (relação da venda e o produto) */
                        cart.CartDetails.FirstOrDefault().Produtos = null; /* limpa para não gerar conflito */
                        cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                        cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                        cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                        _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                        await _context.SaveChangesAsync();
                    }
                }

                return _mapper.Map<CartVO>(cart);
            }
            catch {
                throw;
            }
        }

        public async Task AdicionaCarrinho(Models.Cart cart)
        {
            cart.CartDetails.FirstOrDefault().Produtos = null; /* limpa para não gerar conflito */
            _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FinalizarVenda(CartHeaderVO vo)
        {
            try
            {
                Venda venda = new Venda();
                venda.UserId = vo.UserId;
                venda.Data_Venda = DateTime.Now;
                venda.Total = vo.PurchaseAmount;

                _context.Venda.Add(venda);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
