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
            var clientes = BuscarClientes();

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
                List<string> mensagens = [];
                foreach (var entradaInvalida in ModelState.Where(m =>
                    m.Value?.ValidationState
                    == ModelValidationState.Invalid))
                {
                    string nomeCampo = entradaInvalida.Key;
                    mensagens.Add($"O campo {nomeCampo} é obrigatório!");
                }
                TempData["Mensagens"] = mensagens;
                TempData["Tipo"] = (int)TiposValidacoes.Inconsistencia;
            }
            else
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;
            }


            var clientes = BuscarClientes();

            ViewBag.Clientes = clientes;
            return View(veiculo);
        }

        [HttpGet]
        public IActionResult EditarVeiculo(int id)
        {
            var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {id}");
            var clientes = BuscarClientes();

            ViewBag.Clientes = clientes;
            return View(veiculo);
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
                List<string> mensagens = [];
                foreach (var entradaInvalida in ModelState.Where(m => 
                    m.Value?.ValidationState
                    == ModelValidationState.Invalid))
                {
                    string nomeCampo = entradaInvalida.Key;
                    mensagens.Add($"O campo {nomeCampo} é obrigatório!");
                }
                TempData["Mensagens"] = mensagens;
                TempData["Tipo"] = (int)TiposValidacoes.Inconsistencia;
            }
            else
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;
            }

            var clientes = BuscarClientes();
            
            ViewBag.Clientes = clientes;
            return View(veiculo);
        }

        private IEnumerable<SelectListItem> BuscarClientes()
        {
            var clientes = _contexto.GetMany<Cliente>(new TabelaClientes())
                   .Select(c => new SelectListItem
                   {
                       Value = c.Id.ToString(),
                       Text = c.Nome
                   });

            return clientes;
        }

        [HttpGet]
        public IActionResult DeletarVeiculo(int id)
        {
            var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {id}");
            veiculo.NomeCliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {veiculo.Cliente}").Nome;

            return View(veiculo);
        }

        [HttpPost]
        public IActionResult DeletarVeiculo(Veiculo veiculo)
        {
            if (_validador.ValidarNoDelete(veiculo) is MensagemValidacao mensagemValidacao)
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
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
