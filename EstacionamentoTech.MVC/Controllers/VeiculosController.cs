using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo())
                .Select(v =>
                            new VeiculoViewModel()
                            {
                                Id = v.Id,
                                Cliente = v.Cliente,
                                Nome = v.Nome,
                                Ano = v.Ano,
                                Tipo = v.Tipo,
                                Placa = v.Placa,
                                NomeCliente = _contexto.GetOneOrNull<Cliente>(new TabelaClientes(), $"id = {v.Cliente}")
                                                        ?.Nome ?? " -- "
                            });
            
            return View(veiculos);
        }

        [HttpGet]
        public IActionResult NovoVeiculo()
        {
            List<SelectListItem> clientes = _contexto.GetMany<Cliente>(new TabelaClientes())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();

            ViewBag.Clientes = clientes;
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

        [HttpGet]
        public IActionResult EditarVeiculo(int id)
        {
            var veiculo = _contexto.GetMany<Veiculo>(new TabelaVeiculo(), $"id = {id}").FirstOrDefault();
            if (veiculo != null)
            {
                List<SelectListItem> clientes = _contexto.GetMany<Cliente>(new TabelaClientes())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome,
                        Selected = c.Id == veiculo.Cliente
                    }).ToList();

                ViewBag.Clientes = clientes;
                return View(veiculo);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditarVeiculo(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(new TabelaVeiculo(), veiculo);
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
