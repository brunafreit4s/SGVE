using SGVE_web.Models;
using SGVE_web.Services.IServices;
using System.Threading.Tasks;
using SGVE_web.Util;

namespace SGVE_web.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Funcionario"; //caminho base

        public FuncionarioService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<FuncionarioModel>> FindAllFuncionarios()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<List<FuncionarioModel>>();
        }

        public async Task<FuncionarioModel> FindByIdFuncionario(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<FuncionarioModel>();
        }

        public async Task<FuncionarioModel> CreateFuncionario(FuncionarioModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<FuncionarioModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<FuncionarioModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> DeleteFuncionario(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if(response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }
    }
}
