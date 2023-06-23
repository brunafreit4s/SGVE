using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_VENDAS")]
    public class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public long Id_Venda { get; set; }

        [Column("D_TOTAL")]
        [Required]
        public decimal Total { get; set; }

        [Column("USER_ID")]
        [Required]
        public string UserId { get; set; }

        [Column("DT_VENDA")]
        [StringLength(20)]
        public DateTime Data_Venda { get; set; }
    }
}
