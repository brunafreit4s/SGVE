using SGVE_api.Data.ValueObjects;

namespace SGVE_api.Repository
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<FuncionarioVO>> FindAll();
        
        Task<FuncionarioVO> FindById(long id);
        
        Task<FuncionarioVO> Create(FuncionarioVO vo);
        
        Task<FuncionarioVO> Update(FuncionarioVO vo);
        
        Task<bool> DeleteById(long id);

        //Task<FuncionarioVO> FindByName(string name);
    }
}
