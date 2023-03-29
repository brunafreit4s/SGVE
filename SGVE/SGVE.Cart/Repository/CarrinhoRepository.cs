using AutoMapper;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Models.Context;

namespace SGVE.Cart.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public CarrinhoRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ClearCarrinho(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoVO> FindCarrinhoByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCarrinho(long idVendaxProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoVO> SaveOrUpdateCarrinho(CarrinhoVO carrinho)
        {
            throw new NotImplementedException();
        }
    }
}
