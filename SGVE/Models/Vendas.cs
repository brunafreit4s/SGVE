using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGVE.Models
{
    public class Vendas
    {
        public int COD_VENDA { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string CPF_CLIENTE { get; set; }
        public string DATA_VENDA { get; set; }
        public int NUM_PARCELAS_VENDA { get; set; }
        public double VALOR_PARCELAS_VENDA { get; set; }
        public double DESCONTO_VENDA { get; set; }
        public double TOTAL_VENDA { get; set; }
    }
}
