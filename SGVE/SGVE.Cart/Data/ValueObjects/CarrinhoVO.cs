using SGVE.Cart.Models;

namespace SGVE.Cart.Data.ValueObjects
{
    public class CarrinhoVO
    {
        /*cart*/
        public Venda venda { get; set; }
        public IEnumerable<Venda_x_ProdutoVO> venda_x_produto { get; set; }
    }
}
