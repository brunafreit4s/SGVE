using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGVE_api.Models
{
    [Table("TB_ENDERECO")]
    public class Endereco
    {
        [Key]
        [Column("ID_ENDERECO")]
        [Required]
        public long id { get; set; }

        [Column("I_CEP")]
        [Required]
        [StringLength(8)]
        public int cep { get; set; }

        [Column("V_TIPO_CEP")]
        [Required]
        public string tipoCep { get; set; }

        [Column("V_UF")]
        [Required]
        [StringLength(2)]
        public string uf { get; set; }

        [Column("V_CIDADE")]
        [Required]
        public string cidade { get; set; }

        [Column("V_BAIRRO")]
        [Required]
        public string bairro { get; set; }

        [Column("V_LOGRADOURO")]
        [Required]
        public string logradouro { get; set; }

        [Column("V_COMPLEMENTO")]
        public string complemento { get; set; }

        [Column("V_CD_IBGE")]
        [Required]
        public string codigoIBGE { get; set; }
    }
}
