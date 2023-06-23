using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGVE.Cart.Data.ValueObjects
{
    public class VendaVO
    {
        public long Id_Venda { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public DateTime Data_Venda { get; set; }
    }
}
