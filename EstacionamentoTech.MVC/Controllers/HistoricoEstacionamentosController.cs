using System.Collections.Generic;
using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Enums;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models;
using EstacionamentoTech.MVC.Models.GeracaoArquivos;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstacionamentoTech.MVC.Controllers
{
    public class HistoricoEstacionamentosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _contexto;
        private readonly HistoricoEstacionamentosValidador _validador;

        public HistoricoEstacionamentosController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
            _validador = new HistoricoEstacionamentosValidador(_contexto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var historicos = _contexto.GetMany<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos());
            foreach (var historico in historicos)
            {
                var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {historico.Veiculo}");
                var nomeProprietario = _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {veiculo.Cliente}").Nome;

                historico.IdentificacaoVeiculo = veiculo.Placa.ToUpper() + ", " + veiculo.Nome?.ToUpper() ?? "";
                historico.Proprietario = nomeProprietario;
            }

            return View(historicos);
        }

        private IEnumerable<SelectListItem> BuscarVeiculos()
        {
            var veiculos = _contexto.GetMany<Veiculo>(new TabelaVeiculo())
                    .Select(v => new SelectListItem
                    {
                        Value = v.Id.ToString(),
                        Text = v.Placa + "/" + v.Nome + ", " + _contexto.GetOne<Cliente>(new TabelaClientes(), $"id = {v.Cliente}").Nome
                    });

            return veiculos;
        }

        [HttpGet]
        public IActionResult NovoEstacionamento()
        {
            ViewBag.Veiculos = BuscarVeiculos();
            return View();
        }

        [HttpPost]
        public IActionResult NovoEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            var mensagemValidacao = _validador.ValidarNoCriar(estacionamento);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Insert(new TabelaHistoricoEstacionamentos(), estacionamento);
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

            ViewBag.Veiculos = BuscarVeiculos();
            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult EditarEstacionamento(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");

            ViewBag.Veiculos = BuscarVeiculos();
            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult EditarEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            var mensagemValidacao = _validador.ValidarNoEditar(estacionamento);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                _contexto.Update(new TabelaHistoricoEstacionamentos(), estacionamento);
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

            estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"Id = {estacionamento.Id}");
            ViewBag.Veiculos = BuscarVeiculos();
            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult DeletarEstacionamento(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");
            var veiculo = _contexto.GetOne<Veiculo>(new TabelaVeiculo(), $"id = {estacionamento.Veiculo}");

            estacionamento.Proprietario = _contexto.GetOne<Cliente>(new TabelaClientes(), @$"Id = {veiculo.Cliente}").Nome;
            estacionamento.IdentificacaoVeiculo = veiculo.Placa.ToUpper() + ", " + veiculo.Nome?.ToUpper() ?? "";

            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult DeletarEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            if (_validador.ValidarNoDelete(estacionamento) is MensagemValidacao mensagemValidacao)
            {
                TempData["Mensagens"] = new List<string>() { mensagemValidacao.Mensagem };
                TempData["Tipo"] = (int)mensagemValidacao.Tipo;

                estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"Id = {estacionamento.Id}");
                return View(estacionamento);
            }
            _contexto.Delete(new TabelaHistoricoEstacionamentos(), estacionamento);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FecharEstacionamento(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");

            ViewBag.Veiculos = BuscarVeiculos();
            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult FecharEstacionamento(HistoricoEstacionamentos estacionamento)
        {
            var mensagemValidacao = _validador.ValidarNoFechar(estacionamento);
            var estacionamentoExtensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            bool dadosValidos = ModelState.IsValid;

            if (dadosValidos && mensagemValidacao is null)
            {
                estacionamentoExtensor.CalcularHorasCobradas();
                estacionamentoExtensor.DefinirVigencia();
                estacionamentoExtensor.CalcularValorCobrado();

                _contexto.Update(new TabelaHistoricoEstacionamentos(), estacionamento);
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

            estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {estacionamento.Id}");

            ViewBag.Veiculos = BuscarVeiculos();
            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult PagarEstacionamento(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");

            var extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            extensor.CarregarDadosProprietarioVeiculo();

            ViewBag.FormasDePagamento = new List<SelectListItem>() 
            {
                new SelectListItem { Value = ((int)FormasPagamento.Dinheiro).ToString(), Text = "Dinheiro" },
                new SelectListItem { Value = ((int)FormasPagamento.PIX).ToString(), Text = "PIX" },
                new SelectListItem { Value = ((int)FormasPagamento.Crédito).ToString(), Text = "Crédito" },
                new SelectListItem { Value = ((int) FormasPagamento.Débito).ToString(), Text = "Débito" }
            };
            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult PagarEstacionamento(int id, string formaDePagamento)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");

            estacionamento.Pago = true;
            estacionamento.FormaPagamento = int.Parse(formaDePagamento);

            _contexto.Update(new TabelaHistoricoEstacionamentos(), estacionamento);

            ViewBag.FormasDePagamento = new List<SelectListItem>()
            {
                new SelectListItem 
                { 
                    Value = estacionamento.FormaPagamento.ToString(), 
                    Text = ((FormasPagamento?)estacionamento.FormaPagamento).ToString(),
                    Selected = true
                }
            };

            TempData["Mensagens"] = new List<string> { "Estacionamento pago com sucesso!" };
            TempData["Tipo"] = (int)TiposValidacoes.Informativo;

            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult ArquivoCompra (int id, string? mensagem, TiposValidacoes? tipo)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");

            var extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            extensor.CarregarDadosProprietarioVeiculo();
            extensor.CarregarFormaPagamentoEnum();

            if (mensagem != null && tipo != null)
            {
                TempData["Mensagens"] = new List<string> { mensagem };
                TempData["Tipo"] = (int)tipo;
            }

            return View(estacionamento);
        }


        [HttpGet]
        public async Task<IActionResult> GerarArquivoCompra(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"Id = {id}");

            var extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            extensor.CarregarDadosProprietarioVeiculo();
            extensor.CarregarFormaPagamentoEnum();

            var dto = new ArquivoCompraDataContract()
            {
                Serial = Guid.NewGuid(),
                Veiculo = estacionamento.IdentificacaoVeiculo,
                Proprietario = estacionamento.Proprietario,
                Entrada = estacionamento.Entrada,
                Saida = estacionamento.Saida.Value,
                Valor = estacionamento.ValorCobrado.Value,
                FormaPagamento = estacionamento.FormaPagamentoEnum.ToString()
            };

            return await ExportarArquivoCompra(id, dto);
        }

        private async Task<IActionResult> ExportarArquivoCompra(int id, ArquivoCompraDataContract dto)
        {
            try
            {
                var exportador = new GeradorArquivoCompra();
                var bytes = await exportador.GerarArquivoTxtBytesAsync(dto);

                return File(bytes, "text/plain", $"comprov_pag_{DateTime.Now:ddMMyyyy_HHmmss}.txt");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao gerar arquivo! " + ex.Message;
                var tipo = TiposValidacoes.Inconsistencia;

                return RedirectToAction(
                        nameof(ArquivoCompra),
                        new { id, mensagem, tipo }
                );
            }
        }

        [HttpGet]
        public IActionResult DetalhesEstacionamento(int id)
        {
            var estacionamento = _contexto.GetOne<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), $"id = {id}");
            var extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            extensor.CarregarDadosProprietarioVeiculo();
            extensor.CarregarFormaPagamentoEnum();
            return View(estacionamento);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
