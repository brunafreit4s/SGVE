
namespace SGVE_web.Models
{
    public class CarrinhoViewModel
    {
        /*cart*/
        public VendaViewModel venda { get; set; }
        public IEnumerable<Venda_x_ProdutoViewModel> venda_x_produto { get; set; }
    }
}
