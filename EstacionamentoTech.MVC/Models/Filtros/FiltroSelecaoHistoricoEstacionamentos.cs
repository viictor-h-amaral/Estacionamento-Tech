using EstacionamentoTech.Data.Utilidades;

namespace EstacionamentoTech.MVC.Models.Filtros
{
    public class FiltroSelecaoHistoricoEstacionamentos : IFiltroSelecao
    {
        public CriterioSelecao? CriterioSelecao { get; set ; }
        public string? Placa { get; set; }
        public string? Veiculo { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }

        public FiltroSelecaoHistoricoEstacionamentos(string? placa = null,
                                                     string? veiculo = null,
                                                     DateTime? entrada = null,
                                                     DateTime? saida = null)
        {
            Placa = placa;
            Veiculo = veiculo;
            Entrada = entrada;
            Saida = saida;

            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao()
        {
            var criterioWhere = new List<string>();
            var parametros = new Dictionary<string, object?>();

            if (!string.IsNullOrEmpty(Placa))
            {
                criterioWhere.Add(@$" A.VEICULO IN (SELECT ID 
                                                    FROM estacionamentotechdb.veiculos
                                                    WHERE Placa LIKE @PLACA )");
                parametros["@PLACA"] = "%" + Placa + "%";
            }

            if (!string.IsNullOrEmpty(Veiculo))
            {
                criterioWhere.Add(@$" A.VEICULO IN (SELECT  
                                                    FROM estacionamentotechdb.veiculos
                                                    WHERE NOME LIKE @VEICULO )");
                parametros["@VEICULO"] = "%" + Veiculo + "%";
            }

            if (Entrada.HasValue)
            {
                criterioWhere.Add($" SAIDA >= @ENTRADA ");
                parametros["@ENTRADA"] = Entrada;
            }

            if (Saida != null)
            {
                criterioWhere.Add($" ENTRADA <= @SAIDA ");
                parametros["@SAIDA"] = Saida;
            }

            if (!criterioWhere.Any())
                return;

            string strCriterioWhere = string.Join(" AND ", criterioWhere);
            
            CriterioSelecao = new CriterioSelecao(strCriterioWhere, parametros);
        }
    }
}
