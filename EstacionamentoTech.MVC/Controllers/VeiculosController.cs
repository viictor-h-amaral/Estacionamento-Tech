using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace EstacionamentoTech.MVC.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;

        public VeiculosController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo());
            return View(veiculos);
        }

        [HttpGet]
        public IActionResult NovoVeiculo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoVeiculo(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Insert(new TabelaVeiculo(), veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
