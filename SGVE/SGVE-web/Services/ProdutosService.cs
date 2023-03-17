using SGVE_web.Models;
using SGVE_web.Services.IServices;
using System.Net.Http.Headers;
using SGVE_web.Util;

namespace SGVE_web.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Produtos"; //caminho base

        public ProdutosService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutosModel>> FindAllProdutos(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar");
            return await response.ReadContentAsync<List<ProdutosModel>>();
        }

        public async Task<ProdutosModel> FindByIdProdutos(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar/{id}");
            return await response.ReadContentAsync<ProdutosModel>();
        }

        public async Task<ProdutosModel> CreateProdutos(ProdutosModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/Adicionar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProdutosModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<ProdutosModel> UpdateProdutos(ProdutosModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/Alterar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<ProdutosModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> DeleteProdutos(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/Excluir/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }
    }
}
