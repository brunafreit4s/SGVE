using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGVE.Cart.Models
{
    [Table("TB_VENDAS")]
    public class Vendas
    {
        [Key]
        [Column("ID_VENDA")]
        public long Id_Venda { get; set; }

        [Column("V_USER_ID")]
        [Required]
        public string UserId { get; set; }

        [Column("D_TOTAL")]
        [Required]
        [Range(1, 10000)]
        public decimal Total { get; set; }

        [Column("DT_VENDA")]
        [StringLength(20)]
        public DateTime Data_Venda { get; set; }

    }
}
