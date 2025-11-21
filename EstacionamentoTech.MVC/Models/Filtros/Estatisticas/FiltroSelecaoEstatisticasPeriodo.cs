using EstacionamentoTech.Data.Utilidades;

namespace EstacionamentoTech.MVC.Models.Filtros.Estatisticas
{
    public class FiltroSelecaoEstatisticasPeriodo : IFiltroSelecao
    {
        public CriterioSelecao? CriterioSelecao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string AliasTabela { get; set; } = "A";

        public FiltroSelecaoEstatisticasPeriodo(DateTime? dataInicio,
                                                DateTime? dataFim,
                                                string aliasTabela = "A")
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            AliasTabela = aliasTabela;

            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao(string aliasTabela)
        {
            AliasTabela = aliasTabela;
            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao()
        {
            var criterioWhere = new List<string>();
            var parametros = new Dictionary<string, object?>();

            if (DataInicio.HasValue)
            {
                criterioWhere.Add($" ( {AliasTabela}.SAIDA >= @DATAINICIO ) ");
                parametros["@DATAINICIO"] = DataInicio;
            }

            if (DataFim.HasValue)
            {
                criterioWhere.Add($" {AliasTabela}.ENTRADA <= @DATAFIM ");
                parametros["@DATAFIM"] = DataFim;
            }

            if (!criterioWhere.Any())
                return;

            string strCriterioWhere = string.Join(" AND ", criterioWhere);
            CriterioSelecao = new CriterioSelecao(strCriterioWhere, parametros);
        }
    }
}
