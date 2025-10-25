using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySqlX.XDevAPI;

namespace EstacionamentoTech.MVC.Controllers
{
    public class TabelaValoresController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;
        private readonly IValidador<TabelaValores> _validador;

        public TabelaValoresController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
            _validador = new TabelaValoresValidador(_contexto);
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
            var mensagemValidacao = _validador.ValidarNoCriar(vigencia);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Insert(new TabelaTabelaValores(), vigencia);
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

            return View(vigencia);
        }

        [HttpGet]
        public IActionResult EditarVigencia(int id)
        {
            var vigencia = _contexto.GetOne<TabelaValores>(new TabelaTabelaValores(), $"id = {id}");

            bool possuiEstacionamentosRelacionados = _contexto.TemDependencias<TabelaValores>(vigencia, new TabelaHistoricoEstacionamentos(), "Vigencia");

            if (possuiEstacionamentosRelacionados)
            {
                var consistencia = new MensagemValidacao("VIG_003");
                TempData["Mensagens"] = new List<string> { consistencia.Mensagem };
                TempData["Tipo"] = (int)consistencia.Tipo;
            }

            return View(vigencia);
        }

        [HttpPost]
        public IActionResult EditarVigencia(TabelaValores vigencia)
        {
            var mensagemValidacao = _validador.ValidarNoEditar(vigencia);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Update(new TabelaTabelaValores(), vigencia);
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

            vigencia = _contexto.GetOne<TabelaValores>(new TabelaTabelaValores(), $"Id = {vigencia.Id}");
            return View(vigencia);
        }

        [HttpGet]
        public IActionResult DeletarVigencia(int id)
        {
            var vigencia = _contexto.GetOne<TabelaValores>(new TabelaTabelaValores(), $"id = {id}");

            return View(vigencia);
        }

        [HttpPost]
        public IActionResult DeletarVigencia(TabelaValores vigencia)
        {
            if (_validador.ValidarNoDelete(vigencia) is MensagemValidacao mensagemValidacao)
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;

                vigencia = _contexto.GetOne<TabelaValores>(new TabelaTabelaValores(), $"Id = {vigencia.Id}");
                return View(vigencia);
            }
            _contexto.Delete(new TabelaTabelaValores(), vigencia);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
