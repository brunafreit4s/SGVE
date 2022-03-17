using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGVE.Models
{
    [Table("Funcionario")]
    public class USUARIO
    {        
        public string EMAIL_FUNC { get; set; }
        public string SENHA_FUNC { get; set; }
    }
}
