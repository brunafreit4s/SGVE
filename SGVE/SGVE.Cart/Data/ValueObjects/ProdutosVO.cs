
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGVE.Cart.Data.ValueObjects
{
    public class ProdutosCarrinhoVO
    {
        public long Id_Produto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Id_Tipo { get; set; }
    }
}
