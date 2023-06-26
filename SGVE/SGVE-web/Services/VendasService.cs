using SGVE_web.Models;
using SGVE_web.Services.IServices;
using SGVE_web.Util;
using System.Net.Http.Headers;

namespace SGVE_web.Services
{
    public class VendasService : IVendasService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Vendas"; //caminho base

        public VendasService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<VendasViewModel>> FindAllVendas(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar");
            return await response.ReadContentAsync<List<VendasViewModel>>();
        }
    }
}
