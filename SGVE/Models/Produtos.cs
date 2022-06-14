using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGVE.Models
{
    public class Produtos
    {
        public string COD_BARRAS { get; set; }
        public string NOME_PROD { get; set; }
        public string MARCA_PROD { get; set; }
        public double PRECO_PROD { get; set; }
        public double CUSTO_PROD { get; set; }
        public string DATA_CAD_PROD { get; set; }
        public int QUANTIDADE_PROD { get; set; }
        public string DESC_PROD { get; set; }
    }
}
