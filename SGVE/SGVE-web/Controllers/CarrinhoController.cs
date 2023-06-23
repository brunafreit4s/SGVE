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
        
        public async Task<IActionResult> Remove(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _CarrinhoService.RemoveFromCarrinho(id, accessToken);

            if(response) { return RedirectToAction(nameof(Index)); }

            return View();
        }

        public async Task<IActionResult> Limpar()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _CarrinhoService.ClearCarrinho(userId, accessToken);

            if (response) { return RedirectToAction("Index", "Vendas"); }

            return View();
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
