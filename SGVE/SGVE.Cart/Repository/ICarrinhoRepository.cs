using SGVE.Cart.Data.ValueObjects;

namespace SGVE.Cart.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CartVO> FindCarrinhoByUserId(string userId);
        Task<CartVO> SaveOrUpdateCarrinho(CartVO carrinho);
        Task<bool> RemoveFromCarrinho(long idVendaxProduto);
        Task<bool> ClearCarrinho(string userId);        
    }
}
