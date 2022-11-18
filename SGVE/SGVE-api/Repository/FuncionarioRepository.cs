using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE_api.Data.ValueObjects;
using SGVE_models.Context;
using SGVE_models.Models;

namespace SGVE_api.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public FuncionarioRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioVO>> FindAll()
        {
            List<Funcionario> funcionarios = await _context.Funcionarios.ToListAsync();
            return _mapper.Map<List<FuncionarioVO>>(funcionarios);
        }

        public async Task<FuncionarioVO> FindById(long id)
        {
            Funcionario funcionario 
                = await _context.Funcionarios.Where(f => f.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<FuncionarioVO>(funcionario);
        }
        public async Task<FuncionarioVO> Create(FuncionarioVO vo)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(vo);
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return _mapper.Map<FuncionarioVO>(funcionario);
        }

        public async Task<FuncionarioVO> Update(FuncionarioVO vo)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(vo);
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();

            return _mapper.Map<FuncionarioVO>(funcionario);
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                Funcionario funcionario =
                    await _context.Funcionarios.Where(f => f.Id == id).FirstOrDefaultAsync();
                
                if (funcionario == null) return false;

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
