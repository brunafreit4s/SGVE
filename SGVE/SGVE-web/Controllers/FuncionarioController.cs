using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
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

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FuncionarioModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _funcionarioService.CreateFuncionario(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
