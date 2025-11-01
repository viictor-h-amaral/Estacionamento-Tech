using EstacionamentoTech.Data.Utilidades;

namespace EstacionamentoTech.MVC.Models.Filtros
{
    public class FiltroSelecaoClientes : IFiltroSelecao
    {
        public CriterioSelecao? CriterioSelecao { get; set; }
        public string? NomeCliente { get; set; }

        public FiltroSelecaoClientes(string? nomeCliente = null)
        {
            NomeCliente = nomeCliente;
            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao()
        {
            if (string.IsNullOrEmpty(NomeCliente))
                return;

            CriterioSelecao = new CriterioSelecao($"Nome LIKE '%@PNOME%'");
            CriterioSelecao.AdicionarParametro("@PNOME", NomeCliente);
        }
    }
}
