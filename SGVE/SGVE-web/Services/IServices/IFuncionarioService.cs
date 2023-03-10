using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioModel>> FindAllFuncionarios(string token);
        Task<FuncionarioModel> FindByIdFuncionario(long id, string token);
        //Task<IEnumerable<FuncionarioModel>> FindByNameFuncionario(FuncionarioModel model);
        Task<FuncionarioModel> CreateFuncionario(FuncionarioModel model, string token);
        Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel model, string token);
        Task<bool> DeleteFuncionario(long id, string token);
    }
}
