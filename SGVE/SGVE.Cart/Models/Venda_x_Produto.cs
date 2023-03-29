using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_VENDA_PRODUTO")]
    public class Venda_x_Produto
    {
        [Key]
        [Column("ID_VENDA_PRODUTO")]
        public long Id_Venda_x_Produto { get; set; }

        public long Id_Venda { get; set; }

        [ForeignKey("Id_Venda")]
        public virtual Venda Venda { get; set; }

        public long Id_Produto { get; set; }

        [ForeignKey("Id_Produto")]
        public virtual Produtos Produto { get; set; }

        [Column("COUNT")]
        public int Count { get; set; }
    }
}
