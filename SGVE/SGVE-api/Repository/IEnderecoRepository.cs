using SGVE_api.Data.ValueObjects;

namespace SGVE_api.Repository
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<EnderecoVO>> FindAll();

        Task<EnderecoVO> FindByCep(int cep);
    }
}
