using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("ID_FUNCIONARIO")]
        public long Id { get; set; }
    }
}
