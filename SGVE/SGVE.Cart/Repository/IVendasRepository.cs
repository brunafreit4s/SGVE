using SGVE.Cart.Data.ValueObjects;

namespace SGVE.Cart.Repository
{
    public interface IVendasRepository
    {
        Task<IEnumerable<VendasVO>> FindAll();
    }
}
