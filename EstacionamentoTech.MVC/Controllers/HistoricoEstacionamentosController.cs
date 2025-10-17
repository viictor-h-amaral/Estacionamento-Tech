using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var historicos = _contexto.GetMany<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos());
            foreach (var historico in historicos)
            {
                var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {historico.Veiculo}");
                var nomeProprietario = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {veiculo.Cliente}")?.Nome ?? " -- ";

                historico.IdentificacaoVeiculo = veiculo.Placa.ToUpper() + ", " + veiculo.Nome?.ToUpper() ?? "";
                historico.Proprietario = nomeProprietario;
            }

            return View(historicos);
        }

        [HttpGet]
        public IActionResult NovoEstacionamento()
        {
            List<SelectListItem> veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo())
                    .Select(v => new SelectListItem
                    {
                        Value = v.Id.ToString(),
                        Text = v.Placa +"/"+ v.Nome +", "+ _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {v.Cliente}").Nome
                    }).ToList();

            ViewBag.Veiculos = veiculos;
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
            {
                List<SelectListItem> veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo())
                    .Select(v => new SelectListItem
                    {
                        Value = v.Id.ToString(),
                        Text = v.Placa + "/" + v.Nome + ", " + _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {v.Cliente}").Nome
                    }).ToList();

                ViewBag.Veiculos = veiculos;
                return View(cliente);
            }

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
