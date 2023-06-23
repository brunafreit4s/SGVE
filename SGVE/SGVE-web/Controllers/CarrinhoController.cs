using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ILogger<CarrinhoController> _logger;
        private readonly IProdutosService _ProdutosService;
        private readonly ICarrinhoService _CarrinhoService;

        public CarrinhoController(IProdutosService produtosService, ICarrinhoService carrinhoService)
        {
            _ProdutosService = produtosService;
            _CarrinhoService = carrinhoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await FindUserCart());
        }

        private async Task<CartViewModel> FindUserCart()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _CarrinhoService.FindCarrinhoById(userId, accessToken);

            if (response?.CartHeader != null)
            {
                foreach (var detail in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += (detail.Produtos.Preco * detail.Count);
                }
            }

            return response;
        }
    }
}
