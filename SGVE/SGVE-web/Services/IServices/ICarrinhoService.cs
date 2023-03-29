using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> FindCarrinhoById(string userId, string token);
        Task<CarrinhoViewModel> AddItemToCarrinho(CarrinhoViewModel carrinho, string token);
        Task<CarrinhoViewModel> UpdateCarrinho(CarrinhoViewModel carrinho, string token);
        Task<CarrinhoViewModel> RemoveFromCarrinho(long carrinhoId, string token);
        Task<bool> ClearCarrinho(string userId, string token);
        Task<CarrinhoViewModel> Checkout(VendaViewModel venda, string token);
    }
}
