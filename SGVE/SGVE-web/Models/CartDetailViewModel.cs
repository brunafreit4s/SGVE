namespace SGVE_web.Models
{
    public class CartDetailViewModel
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderViewModel CartHeader { get; set; }
        public long ProdutoId { get; set; }
        public ProdutosViewModel Produtos { get; set; }
        public int Count { get; set; }
    }
}
