using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using EstacionamentoTech.MVC.Models.Filtros;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EstacionamentoTech.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;
        private readonly IValidador<Cliente> _validador;

        public ClientesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
            _validador = new ClienteValidador(_contexto);
        }

        [HttpGet]
        public IActionResult Index(int pagina = 1, int registrosPorPagina = 10, string? NomeBusca = null)
        {
            /* página N contém os registros desde
             * (Último registro da última página + 1), que é o primeiro item da página N,
             * até (Último registro da página N), 
             * ou seja, de (N-1) * RegistrosPorPagina + 1
             * até N * RegistrosPorPagina
             * 
             * => N * RegistrosPorPagina - ((N-1) * RegistrosPorPagina + 1) + 1
             * = N * RegistrosPorPagina - (N-1) * RegistrosPorPagina - 1 + 1
             * = N * RegistrosPorPagina - N * RegistrosPorPagina + RegistrosPorPagina - 1 + 1
             * = RegistrosPorPagina itens na página N
             * 
             * Por isso offSet é o último item da página (N-1), ou
             * (N-1) * RegistrosPorPagina.
             * Exemplo: página 2 com 10 registros por página
             * terá o offset = (2-1) * 10 = 10
             */

            var filtro = new FiltroSelecaoClientes(NomeBusca);

            int offSet = (pagina - 1) * registrosPorPagina;

            var clientes = _contexto.GetManyComPaginacao<Cliente>(
                new TabelaClientes(),
                offSet,
                registrosPorPagina,
                filtro.CriterioSelecao
            );

            int totalRegistros = _contexto.Count<Cliente>(new TabelaClientes(), filtro?.CriterioSelecao);
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.RegistrosPorPagina = registrosPorPagina;
            ViewBag.NomeBusca = filtro?.NomeCliente;

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
            var mensagemValidacao = _validador.ValidarNoCriar(cliente);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Insert(new TabelaClientes(), cliente);
                return RedirectToAction(nameof(Index));
            }
            else if (!dadosValidos)
            {
                List<string> mensagem = [];
                foreach (var entradaInvalida in ModelState.Where(m =>
                    m.Value?.ValidationState
                    == ModelValidationState.Invalid))
                {
                    string nomeCampo = entradaInvalida.Key;
                    mensagem.Add($"O campo {nomeCampo} é obrigatório!");
                }
                TempData["Mensagens"] = mensagem;
                TempData["Tipo"] = (int)TiposValidacoes.Inconsistencia;
            }
            else
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult EditarCliente(int id)
        {
            var cliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {id}");

            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            var mensagemValidacao = _validador.ValidarNoEditar(cliente);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Update(new TabelaClientes(), cliente);
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

            cliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"Id = {cliente.Id}");
            return View(cliente);
        }

        [HttpGet]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {id}");

            return View(cliente);
        }

        [HttpPost]
        public IActionResult DeletarCliente(Cliente cliente)
        {
            
            if (_validador.ValidarNoDelete(cliente) is MensagemValidacao mensagemValidacao)
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;

                cliente = _contexto.GetOne<Cliente>(new TabelaClientes(), $"Id = {cliente.Id}");
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
