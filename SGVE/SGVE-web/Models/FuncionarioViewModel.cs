using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class FuncionarioViewModel
    {
        public long Id { get; set; }

        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF inválido!")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "Nome inválido!")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "RG inválido!")]
        public string Rg { get; set; }

        [Date(ErrorMessage = "Data de Nascimento inválida!")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime Data_Nascimento { get; set; }
        
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Celular inválido!")]
        [Required(ErrorMessage = "Celular é obrigatório")]
        public string Celular { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Telefone inválido!")]
        public string Telefone { get; set; }

        [Integer(ErrorMessage = "CEP inválido!")]
        [Required(ErrorMessage = "CEP é obrigatório")]
        public int Cep_Endereco { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "Endereço inválido!")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Logradouro_Endereco { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "Número inválido!")]
        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero_Endereco { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Complemento inválido!")]
        public string Complemento_Endereco { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Bairro inválido!")]
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro_Endereco { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Cidade inválida!")]
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade_Endereco { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF inválido!")]
        [Required(ErrorMessage = "UF é obrigatório")]
        public string UF_Endereco { get; set; }

        [StringLength(100, MinimumLength = 10, ErrorMessage = "E-mail inválido!")]
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Senha inválida!")]
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }

        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Id_Cargo { get; set; }

    }
}
