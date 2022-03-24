using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGVE.Models
{
    public class Retorno
    {
        [JsonProperty(Order = 1)]
        public List<ERRO> tbERRO { get; set; } = new List<ERRO>();

        [JsonProperty(Order = 2)]
        public List<Usuario> tbUsuario { get; set; } = new List<Usuario>();

        [JsonProperty(Order = 3)]
        public List<Usuario> tbFuncionario { get; set; }
    }

    public class ERRO
    {
        public string strErro { get; set; }
    }
}
