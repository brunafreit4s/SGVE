using SGVE_web.Models;
using System.Collections;

namespace SGVE_web.Services.IServices
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioModel>> FindAllFuncionarios();
        Task<FuncionarioModel> FindByIdFuncionario(long id);
        //Task<IEnumerable<FuncionarioModel>> FindByNameFuncionario(FuncionarioModel model);
        Task<FuncionarioModel> CreateFuncionario(FuncionarioModel model);
        Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel model);
        Task<bool> DeleteFuncionario(long id);


    }
}
