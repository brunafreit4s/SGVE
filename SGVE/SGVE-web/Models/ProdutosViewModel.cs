using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class ProdutosViewModel
    {
        public int Id_Produto { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "Nome inválido!")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "Descrição inválida!")]
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Quandidade é obrigatório")]
        public int Quantidade { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "Marca inválida!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Custo é obrigatório")]
        public decimal Custo { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; }

        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Id_Tipo { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;


        public string SubstringName()
        {
            if (Nome.Length < 24) return Nome;
            else return $"{Nome.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Descricao.Length < 24) return Descricao;
            else return $"{Descricao.Substring(0, 21)} ...";
        }

    }
}
