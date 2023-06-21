using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Cart.Models
{
    [Table("TB_PRODUTO_CARRINHO")]
    public class Produtos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PRODUTO")]
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
        [StringLength(4)]
        public int Quantidade { get; set; }

        [Column("V_MARCA")]
        [StringLength(500)]
        public string Marca { get; set; }

        [Column("D_CUSTO")]
        [Required]
        [Range(1, 10000)]
        public decimal Custo { get; set; }

        [Column("D_PRECO")]
        [Required]
        [Range(1, 10000)]
        public decimal Preco { get; set; }

        [Column("DT_CADASTRO")]
        [StringLength(20)]
        public DateTime Data_Cadastro { get; set; }

        [Column("DT_ALTERACAO")]
        [StringLength(20)]
        public DateTime Data_Alteracao { get; set; }

        [Column("FK_ID_TIPO")]
        public int Id_Tipo { get; set; }
    }
}
