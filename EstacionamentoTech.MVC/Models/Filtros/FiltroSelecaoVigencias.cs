using EstacionamentoTech.Data.Utilidades;

namespace EstacionamentoTech.MVC.Models.Filtros
{
    public class FiltroSelecaoVigencias : IFiltroSelecao
    {
        public CriterioSelecao? CriterioSelecao { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public DateTime? FimVigencia { get; set; }
        public decimal? HoraInicial { get; set; }
        public decimal? HoraAdicional { get; set; }

        public FiltroSelecaoVigencias(DateTime? inicio, DateTime? fim, decimal? horaInicial, decimal? horaAdicional)
        {
            InicioVigencia = inicio;
            FimVigencia = fim;
            HoraInicial = horaInicial;
            HoraAdicional = horaAdicional;

            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao()
        {
            List<string>? criterioWhere = [];
            if (InicioVigencia.HasValue)
            {
                criterioWhere.Add(" DataFim >= @DATAINICIO ");
            }

            if (FimVigencia.HasValue)
            {
                criterioWhere.Add(" DataInicio <= @DATAFIM ");
            }

            if (HoraInicial.HasValue)
            {
                criterioWhere.Add(" ValorHoraInicial = @VALORHORAINICIAL ");
            }

            if (HoraAdicional.HasValue)
            {
                criterioWhere.Add(" ValorHoraAdicional = @VALORHORAADICIONAL");
            }

            if (!criterioWhere.Any())
                return;

            string strCriterioWhere = string.Join(" AND ", criterioWhere);

            CriterioSelecao = new CriterioSelecao(strCriterioWhere);
            CriterioSelecao.AdicionarParametro("@DATAINICIO", InicioVigencia);
            CriterioSelecao.AdicionarParametro("@DATAFIM", FimVigencia);
            CriterioSelecao.AdicionarParametro("@VALORHORAINICIAL", HoraInicial);
            CriterioSelecao.AdicionarParametro("@VALORHORAADICIONAL", HoraAdicional);
        }
    }
}
