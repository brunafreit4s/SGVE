using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class CargosViewModel
    {
        public enum Cargos
        {
            [Display(Name = "Selecione")]
            NULL,
            [Display(Name = "Gerente de Loja")]
            GL,
            [Display(Name = "Gerente de Plantão")]
            GP,
            [Display(Name = "Coordenador de Área")]
            CA,
            [Display(Name = "Treinador")]
            T,
            [Display(Name = "Atendente de Caixa")]
            AC,
            [Display(Name = "Atendente de Loja")]
            AL,
        }
    }
}
