using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE_models.Models
{
    [Table("TB_PRODUTOS")]
    public class Produtos
    {
        [Key]
        [Column("ID_FUNCIONARIO")]
        public long Id { get; set; }

        [Column("V_NOME")]
        [Required]
        [StringLength(500)]
        public string Nome { get; set; }

        [Column("V_DESCRICAO")]
        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("I_QUANTIDADE")]
        [Required]
        public int Quantidade { get; set; }

        [Column("V_MARCA")]
        [StringLength(500)]
        public string Marca { get; set; }

        [Column("D_CUSTO")]
        [Required]        
        public float? Custo { get; set; }

        [Column("D_PRECO")]
        [Required]
        public float? Preco { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime Data_Cadastro { get; set; }

        [Column("FK_ID_TIPO")]
        public int Id_Tipo { get; set; }

        [Column("FK_ID_FORNECEDOR")]
        public int Id_Fornecedor { get; set; }
    }
}
