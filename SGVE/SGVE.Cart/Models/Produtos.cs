using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_PRODUTO")]
    public class Produtos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id_Produto")]
        public long Id_Produto { get; set; }

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
        [Range(1, 10000)]
        public float? Custo { get; set; }

        [Column("D_PRECO")]
        [Required]
        [Range(1,10000)]
        public float? Preco { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime Data_Cadastro { get; set; }

        [Column("FK_ID_TIPO")]
        public int Id_Tipo { get; set; }

        [Column("FK_ID_FORNECEDOR")]
        public int Id_Fornecedor { get; set; }
    }
}
