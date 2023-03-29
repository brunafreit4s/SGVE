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

        public async Task<CarrinhoViewModel> FindCarrinhoById(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar/{userId}");
            return await response.ReadContentAsync<CarrinhoViewModel>();
        }

        public async Task<CarrinhoViewModel> AddItemToCarrinho(CarrinhoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/Adicionar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CarrinhoViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<CarrinhoViewModel> UpdateCarrinho(CarrinhoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/Adicionar", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<CarrinhoViewModel>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<bool> RemoveFromCarrinho(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/Excluir/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception("Ocorreu algum erro na chamada da API!");
        }

        public async Task<CarrinhoViewModel> Checkout(VendaViewModel venda, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCarrinho(string userId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
