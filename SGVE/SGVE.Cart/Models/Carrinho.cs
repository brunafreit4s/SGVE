namespace SGVE.Cart.Models
{
    public class Carrinho
    {
        public Venda venda_x_produto { get; set; }
        public IEnumerable<Venda_x_Produto> vendas { get; set; }
    }
}
