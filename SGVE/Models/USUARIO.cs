using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGVE.Models
{
    [Table("Funcionario")]
    public class Usuario
    {      
        [Key]
        public int COD_FUNC { get; set; }
        public string EMAIL_FUNC { get; set; }
        public string SENHA_FUNC { get; set; }
    }
}
