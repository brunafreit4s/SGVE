using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE.Cart.Models.Context;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Models;

namespace SGVE.Cart.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public VendasRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendasVO>> FindAll()
        {
            List<Vendas> vendas = await _context.Vendas.ToListAsync();
            return _mapper.Map<List<VendasVO>>(vendas);
        }
    }
}
