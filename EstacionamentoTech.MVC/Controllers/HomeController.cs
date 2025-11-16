using System.Diagnostics;
using EstacionamentoTech.Data;
using EstacionamentoTech.MVC.Models;
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

        public IActionResult Index()
        {
            var mediaEstacionamentosCliente = CalcularMediaEstacionamentosPorCliente();
            var mediaTempoEfetivoEstacionamentos = CalcularMediaTempoEfetivoEstacionamentos();
            var mediaTempoCobradoEstacionamentos = CalcularMediaTempoCobradoEstacionamentos();
            var clienteComMaisEstacionamentos = RetornarClienteComMaiorNumeroDeEstacionamentos();

            ViewBag.MediaEstacionamentosCliente = mediaEstacionamentosCliente.ToString();
            ViewBag.MediaTempoEfetivoEstacionamentos = ConverterDecimalEmTempo(mediaTempoEfetivoEstacionamentos);
            ViewBag.MediaTempoCobradoEstacionamentos = ConverterDecimalEmTempo(mediaTempoCobradoEstacionamentos);
            ViewBag.ClienteComMaisEstacionamentos = clienteComMaisEstacionamentos;

            return View();
        }

        private long CalcularMediaEstacionamentosPorCliente()
        {
            return _contexto.RetornarMediaEstacionamentosPorCliente();
        }

        private decimal CalcularMediaTempoEfetivoEstacionamentos()
        {
            return Math.Round(_contexto.RetornarMediaTempoEfetivoEstacionamentos());
        }

        private decimal CalcularMediaTempoCobradoEstacionamentos()
        {
            return Math.Round(_contexto.RetornarMediaTempoCobradoEstacionamentos());
        }

        private string ConverterDecimalEmTempo(decimal minutos)
        {
            return  minutos > 60
                    ?   $"{Math.Round(minutos / 60, 0)}h{minutos % 60}min"
                    :   $"{minutos}min";
        }

        private string RetornarClienteComMaiorNumeroDeEstacionamentos()
        {
            return _contexto.RetornarClienteComMaiorNumeroDeEstacionamentos();
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
