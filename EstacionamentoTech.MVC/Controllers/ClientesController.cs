using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoTech.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;

        public ClientesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var clientes = _contexto.GetMany<Cliente>(new TabelaClientes());
            return View(clientes);
        }

        [HttpGet]
        public IActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Insert(new TabelaClientes(), cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult EditarCliente(int id)
        {
            var cliente = _contexto.GetMany<Cliente>(new TabelaClientes(), $"id = {id}").FirstOrDefault();
            if (cliente != null)
                return View(cliente);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(new TabelaClientes(), cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _contexto.GetMany<Cliente>(new TabelaClientes(), $"id = {id}").FirstOrDefault();
            if (cliente != null)
            {
                return View(cliente);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeletarCliente(Cliente cliente)
        {
            if (_contexto.TemDependencias(cliente, new TabelaVeiculo(), "Cliente"))
            {
                TempData["ErrorMessage"] = "Cliente está registrado como proprietário de um veículo!";
                return View(cliente);
            }
            _contexto.Delete(new TabelaClientes(), cliente);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
