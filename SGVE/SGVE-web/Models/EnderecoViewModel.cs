using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class EnderecosViewModel
    {
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
