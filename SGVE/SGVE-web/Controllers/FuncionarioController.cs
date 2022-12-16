using Microsoft.AspNetCore.Mvc;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
        }

        public async Task<ActionResult> Index()
        {
            var funcionarios = await _funcionarioService.FindAllFuncionarios();
            return View(funcionarios);
        }
    }
}
