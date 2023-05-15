using SGVE_web.Models;
using SGVE_web.Util;
using System.Net.Http.Headers;

namespace SGVE_web.Services
{
    public class EnderecoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Endereco"; //caminho base

        public EnderecoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<EnderecosViewModel>> FindAllEnderecos(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar");
            return await response.ReadContentAsync<List<EnderecosViewModel>>();
        }

        public async Task<EnderecosViewModel> FindByCepEndereco(int cep, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/Consultar/{cep}");
            return await response.ReadContentAsync<EnderecosViewModel>();
        }
    }
}
