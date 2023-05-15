using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE_api.Context;
using SGVE_api.Data.ValueObjects;
using SGVE_api.Models;

namespace SGVE_api.Repository
{
    public class EnderecoRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public EnderecoRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EnderecoVO>> FindAll()
        {
            List<Endereco> enderecos = await _context.Endereco.ToListAsync();
            return _mapper.Map<List<EnderecoVO>>(enderecos);
        }
    }
}
