using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioViewModel>> FindAllFuncionarios(string token);
        Task<FuncionarioViewModel> FindByIdFuncionario(long id, string token);
        //Task<IEnumerable<FuncionarioModel>> FindByNameFuncionario(FuncionarioModel model);
        Task<FuncionarioViewModel> CreateFuncionario(FuncionarioViewModel model, string token);
        Task<FuncionarioViewModel> UpdateFuncionario(FuncionarioViewModel model, string token);
        Task<bool> DeleteFuncionario(long id, string token);
    }
}