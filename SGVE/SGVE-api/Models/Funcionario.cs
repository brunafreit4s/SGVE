using SGVE_models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVE_models.Models
{
    [Table("TB_FUNCIONARIO")]
    public class Funcionario : BaseEntity
    {
        [Key]
        [Column("ID_FUNCIONARIO")]
        public int? Id { get; set; }

        [Column("V_CPF")]
        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }

        [Column("V_NOME")]
        [Required]
        [StringLength(500)]
        public string? Nome { get; set; }
         
        [Column("V_RG")]
        [StringLength(20)]
        public string? Rg { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime Data_Nascimento { get; set; }

        [Column("V_DDD_CELULAR")]
        [StringLength(3)]
        public string? DDD_Celular { get; set; }

        [Column("V_CELULAR")]
        [StringLength(15)]
        public string? Celular { get; set; }

        [Column("V_DDD_TELEFONE")]
        [StringLength(3)]
        public string? DDD_Telefone { get; set; }

        [Column("V_TELEFONE")]
        [StringLength(15)]
        public string? Telefone { get; set; }

        [Column("FK_ID_ENDERECO")]
        [StringLength(15)]
        public int Id_Endereco { get; set; }

        [Column("I_NUM_ENDERECO")]
        [StringLength(20)]
        public string? Numero_Endereco { get; set; }

        [Column("V_COMPLEMENTO")]
        [StringLength(500)]
        public string? Complemento_Endereco { get; set; }

        [Column("V_EMAIL")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Column("V_SENHA")]
        [StringLength(20)]
        public string? Senha { get; set; }

        [Column("DT_CADASTRO")]
        [StringLength(20)]
        public DateTime Data_Cadastro { get; set; }

        [Column("DT_DESLIGAMENTO")]
        [StringLength(20)]
        public DateTime Data_Desligamento { get; set; }

        [Column("FK_ID_CARGO")]
        [StringLength(15)]
        public int Id_Cargo { get; set; }

    }
}
