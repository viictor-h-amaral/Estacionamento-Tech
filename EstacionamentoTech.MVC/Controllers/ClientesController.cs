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

        public ClientesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _contexto = new Context();
        }

        private readonly Context _contexto;
        /*public ClientesController(Context contexto)
        {
            _contexto = contexto;
        }*/

        public IActionResult Index()
        {
            var clientes = _contexto.GetMany<Cliente>(new TabelaClientes());
            return View(clientes);
        }

        public IActionResult NovoCliente()
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
