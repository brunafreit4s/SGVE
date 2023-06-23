using SGVE_web.Models;
using SGVE_web.Services.IServices;
using SGVE_web.Util;
using System.Net.Http.Headers;

namespace SGVE_web.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Carrinho"; //caminho base

        public CarrinhoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCarrinhoById(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar/{userId}");
            if (!response.IsSuccessStatusCode) return new CartViewModel();
            return await response.ReadContentAsync<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCarrinho(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/Adicionar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CartViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<CartViewModel> UpdateCarrinho(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/Alterar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CartViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> RemoveFromCarrinho(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/Deletar/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> Finalizar(CartHeaderViewModel venda, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/Finalizar", venda);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> ClearCarrinho(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Limpar/{userId}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }
    }
}
