using EstacionamentoTech.Data.Utilidades;

namespace EstacionamentoTech.MVC.Models.Filtros
{
    public interface IFiltroSelecao
    {
        CriterioSelecao? CriterioSelecao { get; set; }

        void GerarCriterioSelecao();
    }
}
