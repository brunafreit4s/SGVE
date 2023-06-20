using System.ComponentModel.DataAnnotations;

namespace SGVE_web.Models
{
    public class TiposViewModel
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

        public enum Produtos
        {
            [Display(Name = "Selecione")]
            NULL,
            [Display(Name = "Alimento")]
            ALIMENTO,
            [Display(Name = "Bebida")]
            BEBIDA,
            [Display(Name = "Higiene")]
            HIGIENE,
            [Display(Name = "Limpeza")]
            LIMPEZA,
            [Display(Name = "Medicamento")]
            MEDICAMENTO,
            [Display(Name = "Plástico")]
            PLASTICO,
            [Display(Name = "Papel")]
            PAPEL,
            [Display(Name = "Roupa")]
            ROUPA,
        }
    }
}
