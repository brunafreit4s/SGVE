
namespace SGVE.Cart.Data.ValueObjects
{
    public class CarrinhoVO
    {
        public VendaVO venda { get; set; }
        public IEnumerable<Venda_x_ProdutoVO> venda_x_produto { get; set; }
    }
}
