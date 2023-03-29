using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_VENDA")]
    public class Venda
    {
        [Key]
        [Column("Id_Venda")]
        public long Id_Venda { get; set; }

        [Column("V_USER_ID")]
        public string UserId { get; set; }

    }
}
