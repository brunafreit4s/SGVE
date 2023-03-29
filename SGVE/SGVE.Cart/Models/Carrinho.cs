namespace SGVE.Cart.Models
{
    public class Carrinho
    {
        public Venda vendas { get; set; }
        public IEnumerable<Venda_x_Produto> venda_x_produto { get; set; }
    }
}
