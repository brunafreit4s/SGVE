using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IProdutosService
    {
        Task<IEnumerable<ProdutosViewModel>> FindAllProdutos(string token);
        Task<List<ProdutosViewModel>> FindAllProdutosChart(string token);
        Task<ProdutosViewModel> FindByIdProdutos(long id, string token);
        Task<ProdutosViewModel> CreateProdutos(ProdutosViewModel model, string token);
        Task<ProdutosViewModel> UpdateProdutos(ProdutosViewModel model, string token);
        Task<bool> DeleteProdutos(long id, string token);
    }
}
