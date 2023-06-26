
using System.Security.Policy;

namespace SGVE_web.Models
{
    public class Retorno
    {
        public List<ProdutosViewModel> Produtos = new List<ProdutosViewModel>();
        public IEnumerable<FuncionarioViewModel> Funcionario = new List<FuncionarioViewModel>();
        public IEnumerable<VendasViewModel> Vendas = new List<VendasViewModel>();
    }
}
