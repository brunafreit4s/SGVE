using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class VendasController : Controller
    {
        private readonly ILogger<VendasController> _logger;
        private readonly IProdutosService _ProdutosService;
        private readonly ICarrinhoService _CarrinhoService;

        public VendasController(IProdutosService produtosService, ICarrinhoService carrinhoService)
        {
            _ProdutosService = produtosService;
            _CarrinhoService = carrinhoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _ProdutosService.FindAllProdutos(accessToken);
            return View(Produtos);
        }

        [Authorize]
        public async Task<IActionResult> Remover(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _CarrinhoService.RemoveFromCarrinho(id ,accessToken);
            return View(Produtos);
        }

        [Authorize]
        public async Task<IActionResult> Detalhe(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var model = await _ProdutosService.FindByIdProdutos(id, accessToken);
            return View(model);
        }
        
        [HttpPost]
        [ActionName("Detalhe")]
        [Authorize]
        public async Task<ActionResult> DetalhePost(ProdutosViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */

            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                Count = model.Count,
                ProdutoId = model.Id_Produto,
                Produtos = await _ProdutosService.FindByIdProdutos(model.Id_Produto, token)
            };

            List<CartDetailViewModel> cartDetails = new List<CartDetailViewModel>();
            cartDetails.Add(cartDetail);
            cart.CartDetails = cartDetails;

            var response = await _CarrinhoService.AddItemToCarrinho(cart, token);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }
}
