namespace SGVE.Cart.Data.ValueObjects
{
    public class CartDetailVO
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderVO CartHeader { get; set; }
        public long ProdutoId { get; set; }
        public ProdutosVO Produtos { get; set; }
        public int Count { get; set; }
    }
}
