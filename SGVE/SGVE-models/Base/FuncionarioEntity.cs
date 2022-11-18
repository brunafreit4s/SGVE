using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE_models.Base
{
    public class FuncionarioEntity
    {
        [Key]
        [Column("CD_FUNC")]
        public long Id { get; set; }
    }
}
