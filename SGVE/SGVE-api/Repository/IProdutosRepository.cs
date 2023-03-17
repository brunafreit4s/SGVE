using SGVE_api.Data.ValueObjects;

namespace SGVE_api.Repository
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<ProdutosVO>> FindAll();

        Task<ProdutosVO> FindById(long id);

        Task<ProdutosVO> Create(ProdutosVO vo);

        Task<ProdutosVO> Update(ProdutosVO vo);

        Task<bool> DeleteById(long id);

        //Task<ProdutosVO> FindByName(string name);
    }
}
