using System.Security.Policy;

namespace SGVE_web.Models
{
    public class Retorno
    {
        public List<ProdutosChartViewModel> Produtos = new List<ProdutosChartViewModel>();
        public IEnumerable<FuncionarioViewModel> Funcionario = new List<FuncionarioViewModel>();
    }
}
