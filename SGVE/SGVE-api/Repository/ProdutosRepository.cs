using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE_api.Data.ValueObjects;
using SGVE_models.Context;
using SGVE_models.Models;

namespace SGVE_api.Repository
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public ProdutosRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutosVO>> FindAll()
        {
            List<Produtos> Produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutosVO>>(Produtos);
        }

        public async Task<ProdutosVO> FindById(long id)
        {
            Produtos Produtos = await _context.Produtos.Where(f => f.Id == id).FirstOrDefaultAsync() ?? new Produtos();

            return _mapper.Map<ProdutosVO>(Produtos);
        }
        public async Task<ProdutosVO> Create(ProdutosVO vo)
        {
            Produtos Produtos = _mapper.Map<Produtos>(vo);
            _context.Produtos.Add(Produtos);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProdutosVO>(Produtos);
        }

        public async Task<ProdutosVO> Update(ProdutosVO vo)
        {
            Produtos Produtos = _mapper.Map<Produtos>(vo);
            _context.Produtos.Update(Produtos);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProdutosVO>(Produtos);
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                Produtos Produtos = await _context.Produtos.Where(f => f.Id == id).FirstOrDefaultAsync() ?? new Produtos();

                if (Produtos.Id <= 0) return false;

                _context.Produtos.Remove(Produtos);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
