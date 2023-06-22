using SGVE.Cart.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_CART_DETAIL")]
    public class CartDetail : BaseEntity
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }

        public long ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produtos Produtos { get; set; }

        [Column("I_COUNT")]
        public int Count { get; set; }

    }
}
