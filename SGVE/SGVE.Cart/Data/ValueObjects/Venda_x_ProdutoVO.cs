
namespace SGVE.Cart.Data.ValueObjects
{
    public class Venda_x_ProdutoVO
    {
        /*CartDetail*/
        public long Id_Venda_x_Produto { get; set; }
        public long Id_Venda { get; set; }
        public VendaVO Venda { get; set; }
        public long Id_Produto { get; set; }
        public ProdutosVO Produto { get; set; }
        public int Count { get; set; }
    }
}
