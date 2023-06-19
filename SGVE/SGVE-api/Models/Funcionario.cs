using SGVE_api.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE_api.Models
{
    [Table("TB_FUNCIONARIO")]
    public class Funcionario : BaseEntity
    {
        [Column("V_CPF")]
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Column("V_NOME")]
        [Required]
        [StringLength(500)]
        public string Nome { get; set; }
         
        [Column("V_RG")]
        [StringLength(20)]
        public string Rg { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime Data_Nascimento { get; set; }

        [Column("V_CELULAR")]
        [StringLength(15)]
        public string Celular { get; set; }

        [Column("V_TELEFONE")]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Column("I_CEP_ENDERECO")]
        [StringLength(15)]
        public int Cep_Endereco { get; set; }

        [Column("V_LOGRADOURO_ENDERECO")]
        [StringLength(500)]
        public string Logradouro_Endereco { get; set; }

        [Column("I_NUM_ENDERECO")]
        [StringLength(10)]
        public string Numero_Endereco { get; set; }

        [Column("V_COMPLEMENTO_ENDERECO")]
        [StringLength(100)]
        public string Complemento_Endereco { get; set; }

        [Column("V_BAIRRO_ENDERECO")]
        [StringLength(100)]
        public string Bairro_Endereco { get; set; }

        [Column("V_CIDADE_ENDERECO")]
        [StringLength(100)]
        public string Cidade_Endereco { get; set; }

        [Column("V_UF_ENDERECO")]
        [StringLength(2)]
        public string UF_Endereco { get; set; }

        [Column("V_EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("V_SENHA")]
        [StringLength(20)]
        public string Senha { get; set; }

        [Column("DT_CADASTRO")]
        [StringLength(20)]
        public DateTime Data_Cadastro { get; set; }

        [Column("DT_ALTERACAO")]
        [StringLength(20)]
        public DateTime Data_Alteracao { get; set; }

        [Column("FK_ID_CARGO")]
        [StringLength(1)]
        public int Id_Cargo { get; set; }

    }
}
