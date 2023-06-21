using SGVE.Cart.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_VENDA")]
    public class Venda : BaseEntity
    {
        [Column("V_USER_ID")]
        public string UserId { get; set; }
    }
}
