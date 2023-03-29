using SGVE.Cart.Data.ValueObjects;

namespace SGVE.Cart.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoVO> FindCarrinhoByUserId(string userId);
        Task<CarrinhoVO> SaveOrUpdateCarrinho(CarrinhoVO carrinho);
        Task<bool> RemoveFromCarrinho(long idVendaxProduto);
        Task<bool> ClearCarrinho(string userId);        
    }
}
