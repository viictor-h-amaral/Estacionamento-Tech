using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI;

namespace EstacionamentoTech.MVC.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;
        private readonly IValidador<Veiculo> _validador;

        public VeiculosController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
            _validador = new VeiculoValidador(_contexto);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo());
            foreach (var veiculo in veiculos)
            {
                veiculo.NomeCliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {veiculo.Cliente}").Nome;
            }

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
            var mensagemValidacao = _validador.ValidarNoCriar(veiculo);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Insert(new TabelaVeiculo(), veiculo);
                return RedirectToAction(nameof(Index));
            }
            else if (!dadosValidos)
            {
                string mensagem = string.Empty;
                foreach (var entradaInvalida in ModelState.Where(m =>
                    m.Value?.ValidationState
                    == ModelValidationState.Invalid))
                {
                    string nomeCampo = entradaInvalida.Key;
                    mensagem += $"O campo {nomeCampo} é obrigatório! \n";
                }
                TempData["Mensagem"] = mensagem;
                TempData["Tipo"] = (int)TiposValidacoes.Inconsistencia;
            }
            else
            {
                TempData["Mensagem"] = mensagemValidacao.Mensagem;
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;
            }


            List<SelectListItem> clientes = _contexto.GetMany<Cliente>(new TabelaClientes())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();

            ViewBag.Clientes = clientes;
            return View(veiculo);
        }

        [HttpGet]
        public IActionResult EditarVeiculo(int id)
        {
            var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {id}");
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
            veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"Id = {veiculo.Id}");
            var mensagemValidacao = _validador.ValidarNoEditar(veiculo);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Update(new TabelaVeiculo(), veiculo);
                return RedirectToAction(nameof(Index));
            }
            else if (!dadosValidos)
            {
                string mensagem = string.Empty;
                foreach (var entradaInvalida in ModelState.Where(m => 
                    m.Value?.ValidationState
                    == ModelValidationState.Invalid))
                {
                    string nomeCampo = entradaInvalida.Key;
                    mensagem += $"O campo {nomeCampo} é obrigatório! \n";
                }
                TempData["Mensagem"] = mensagem;
                TempData["Tipo"] = (int)TiposValidacoes.Inconsistencia;
            }
            else
            {
                TempData["Mensagem"] = mensagemValidacao.Mensagem;
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;
            }

            List<SelectListItem> clientes = _contexto.GetMany<Cliente>(new TabelaClientes())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();

            ViewBag.Clientes = clientes;
            return View(veiculo);
        }

        [HttpGet]
        public IActionResult DeletarVeiculo(int id)
        {
            var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {id}");
            veiculo.NomeCliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {veiculo.Cliente}").Nome;

            if (veiculo != null)
                return View(veiculo);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeletarVeiculo(Veiculo veiculo)
        {

            if (_validador.ValidarNoDelete(veiculo) is MensagemValidacao mensagemValidacao)
            {
                TempData["Mensagem"] = mensagemValidacao.Mensagem;
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;

                veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"Id = {veiculo.Id}");
                return View(veiculo);
            }
            _contexto.Delete(new TabelaVeiculo(), veiculo);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
