using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecosViewModel>> FindAllEnderecos(string token);
        Task<EnderecosViewModel> FindByCepEndereco(int cep, string token);
    }
}
