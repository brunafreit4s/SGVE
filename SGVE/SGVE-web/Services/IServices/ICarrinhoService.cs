using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface ICarrinhoService
    {
        Task<CartViewModel> FindCarrinhoById(string userId, string token);
        Task<CartViewModel> AddItemToCarrinho(CartViewModel carrinho, string token);
        Task<CartViewModel> UpdateCarrinho(CartViewModel carrinho, string token);
        Task<bool> RemoveFromCarrinho(long carrinhoId, string token);
        Task<bool> ClearCarrinho(string userId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel venda, string token);
    }
}
