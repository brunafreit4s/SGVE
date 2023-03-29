using SGVE_web.Models;
using SGVE_web.Services.IServices;
using System.Net.Http.Headers;
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

        public async Task<IEnumerable<FuncionarioViewModel>> FindAllFuncionarios(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar");
            return await response.ReadContentAsync<List<FuncionarioViewModel>>();
        }

        public async Task<FuncionarioViewModel> FindByIdFuncionario(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar/{id}");
            return await response.ReadContentAsync<FuncionarioViewModel>();
        }

        public async Task<FuncionarioViewModel> CreateFuncionario(FuncionarioViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/Adicionar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<FuncionarioViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<FuncionarioViewModel> UpdateFuncionario(FuncionarioViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/Alterar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<FuncionarioViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> DeleteFuncionario(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/Excluir/{id}");
            if(response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }
    }
}
