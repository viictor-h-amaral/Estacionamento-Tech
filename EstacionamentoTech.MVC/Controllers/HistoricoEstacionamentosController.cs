using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoTech.MVC.Controllers
{
    public class HistoricoEstacionamentosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;

        public HistoricoEstacionamentosController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var historico = _contexto.GetMany<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos());
            return View(historico);
        }

        [HttpGet]
        public IActionResult NovoEstacionamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Insert(new TabelaHistoricoEstacionamentos(), estacionamento);
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult EditarEstacionamento(int id)
        {
            var cliente = _contexto.GetMany<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}").FirstOrDefault();
            if (cliente != null)
                return View(cliente);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditarEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(new TabelaHistoricoEstacionamentos(), estacionamento);
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
