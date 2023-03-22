using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IProdutosService
    {
        Task<IEnumerable<ProdutosModel>> FindAllProdutos(string token);
        Task<IEnumerable<ProdutosChart>> FindAllProdutosChart(string token);
        Task<ProdutosModel> FindByIdProdutos(long id, string token);
        //Task<IEnumerable<ProdutosModel>> FindByNameProdutos(ProdutosModel model);
        Task<ProdutosModel> CreateProdutos(ProdutosModel model, string token);
        Task<ProdutosModel> UpdateProdutos(ProdutosModel model, string token);
        Task<bool> DeleteProdutos(long id, string token);
    }
}
