using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoTech.MVC.Controllers
{
    public class TabelaValoresController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;

        public TabelaValoresController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vigencias = _contexto.GetMany<TabelaValores>(new TabelaTabelaValores());
            return View(vigencias);
        }

        [HttpGet]
        public IActionResult NovaVigencia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovaVigencia(TabelaValores vigencia)
        {
            if (ModelState.IsValid)
            {
                _contexto.Insert(new TabelaTabelaValores(), vigencia);
                return RedirectToAction(nameof(Index));
            }
            return View(vigencia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
