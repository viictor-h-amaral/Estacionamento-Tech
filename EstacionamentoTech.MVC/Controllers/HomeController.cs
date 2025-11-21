using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.MVC.Models;
using EstacionamentoTech.MVC.Models.Filtros;
using EstacionamentoTech.MVC.Models.Filtros.Estatisticas;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoTech.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _contexto;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }

        public IActionResult Index(DateTime? Inicio = null,
                                   DateTime? Fim = null)
        {
            var filtro = new FiltroSelecaoEstatisticasPeriodo(Inicio, Fim);

            var mediaEstacionamentosCliente = CalcularMediaEstacionamentosPorCliente(filtro);
            var mediaTempoEfetivoEstacionamentos = CalcularMediaTempoEfetivoEstacionamentos(filtro);
            var mediaTempoCobradoEstacionamentos = CalcularMediaTempoCobradoEstacionamentos(filtro);
            var clienteComMaisEstacionamentos = RetornarClienteComMaiorNumeroDeEstacionamentos(filtro);
            var quantidadeEstacionamentosEmAberto = RetornarQuantidadeEstacionamentosEmAberto();
            var veiculosAPagar = RetornarQuantidadeVeiculosAPagar();

            ViewBag.MediaEstacionamentosCliente = mediaEstacionamentosCliente.ToString();
            ViewBag.MediaTempoEfetivoEstacionamentos = ConverterDecimalEmTempo(mediaTempoEfetivoEstacionamentos);
            ViewBag.MediaTempoCobradoEstacionamentos = ConverterDecimalEmTempo(mediaTempoCobradoEstacionamentos);
            ViewBag.ClienteComMaisEstacionamentos = clienteComMaisEstacionamentos;
            ViewBag.QuantidadeEstacionamentosEmAberto = quantidadeEstacionamentosEmAberto.ToString();
            ViewBag.VeiculosAPagar = veiculosAPagar.ToString();

            ViewBag.Inicio = Inicio?.ToString("yyyy-MM-dd");
            ViewBag.Fim = Fim?.ToString("yyyy-MM-dd");

            return View();
        }

        private int CalcularMediaEstacionamentosPorCliente(FiltroSelecaoEstatisticasPeriodo filtro)
        {
            filtro.GerarCriterioSelecao(aliasTabela: "A");
            return _contexto.RetornarMediaEstacionamentosPorCliente(filtro.CriterioSelecao);
        }

        private decimal CalcularMediaTempoEfetivoEstacionamentos(FiltroSelecaoEstatisticasPeriodo filtro)
        {
            filtro.GerarCriterioSelecao(aliasTabela: "A");
            return Math.Round(_contexto.RetornarMediaTempoEfetivoEstacionamentos(filtro.CriterioSelecao));
        }

        private decimal CalcularMediaTempoCobradoEstacionamentos(FiltroSelecaoEstatisticasPeriodo filtro)
        {
            filtro.GerarCriterioSelecao(aliasTabela: "A");
            return Math.Round(_contexto.RetornarMediaTempoCobradoEstacionamentos(filtro.CriterioSelecao));
        }

        private string RetornarClienteComMaiorNumeroDeEstacionamentos(FiltroSelecaoEstatisticasPeriodo filtro)
        {
            filtro.GerarCriterioSelecao(aliasTabela: "C");
            return _contexto.RetornarClienteComMaiorNumeroDeEstacionamentos(filtro.CriterioSelecao);
        }

        private int RetornarQuantidadeEstacionamentosEmAberto()
        {
            return _contexto.RetornarQuantidadeEstacionamentosEmAberto();
        }

        private int RetornarQuantidadeVeiculosAPagar()
        {
            return _contexto.RetornarQuantidadeVeiculosAPagar();
        }

        private string ConverterDecimalEmTempo(decimal minutos)
        {
            return minutos > 60
                    ? $"{Math.Round(minutos / 60, 0)}h{minutos % 60}min"
                    : $"{minutos}min";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
