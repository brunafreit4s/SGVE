namespace SGVE.Cart.Data.ValueObjects
{
    public class CarrinhoVO
    {
        /*cart*/
        public VendaVO venda_x_produto { get; set; }
        public IEnumerable<Venda_x_ProdutoVO> vendas { get; set; }
    }
}
