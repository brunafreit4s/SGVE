
namespace SGVE_web.Models
{
    public class Venda_x_ProdutoViewModel
    {
        /*CartDetails*/
        public long Id_Venda_x_Produto { get; set; }
        public long Id_Venda { get; set; }
        public VendaViewModel Venda { get; set; }
        public long Id_Produto { get; set; }
        public ProdutosViewModel Produto { get; set; }
        public int Count { get; set; }
    }
}
