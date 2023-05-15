using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class EnderecosViewModel
    {
        public int idFuncionario { get; set; }
        public int cep { get; set; }
        public string tipoCep { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string codigoIBGE { get; set; }

        public enum Enderecos
        {
            [Display(Name = "Selecione")]
            NULL,
            [Display(Name = "São Paulo")]
            SP,
            [Display(Name = "Rio de Janeiro")]
            RJ,
            [Display(Name = "Minas Gerais")]
            MG,
            [Display(Name = "Paraná")]
            PR,
            [Display(Name = "Santa Catarina")]
            SC,
            [Display(Name = "Rio Grande do Sul")]
            RS,
            [Display(Name = "Bahia")]
            BA,
            [Display(Name = "Pernambuco")]
            PE,
            [Display(Name = "Amazonas")]
            AM,
            [Display(Name = "Pará")]
            PA,
            [Display(Name = "Rondônia")]
            RO,
            [Display(Name = "Mato Grosso")]
            MS
        }
    }
}
