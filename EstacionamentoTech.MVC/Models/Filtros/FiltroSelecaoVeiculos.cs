using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;

namespace EstacionamentoTech.MVC.Models.Filtros
{
    public class FiltroSelecaoVeiculos : IFiltroSelecao
    {
        public CriterioSelecao? CriterioSelecao { get; set; }
        public string? Placa { get; set; }
        public string? Nome { get; set; }
        public string? Cliente { get; set; }
        public string? Tipo { get; set; }

        public FiltroSelecaoVeiculos(string? placa = null,
                                     string? nome = null,
                                     string? cliente = null,
                                     string? tipo = null)
        {
            Placa = placa;
            Nome = nome;
            Cliente = cliente;
            Tipo = tipo;

            GerarCriterioSelecao();
        }

        public void GerarCriterioSelecao()
        {
            var criterioWhere = new List<string>();
            var parametros = new Dictionary<string, object?>();

            if (!string.IsNullOrEmpty(Placa))
            {
                criterioWhere.Add(" A.PLACA LIKE @PLACA ");
                parametros["@PLACA"] = "%" + Placa + "%";
            }

            if (!string.IsNullOrEmpty(Nome))
            {
                criterioWhere.Add(" A.NOME LIKE @NOME ");
                parametros["@NOME"] = "%" + Nome + "%";
            }

            if (!string.IsNullOrEmpty(Cliente))
            {
                criterioWhere.Add(@" A.CLIENTE IN (SELECT A.ID 
                                                FROM estacionamentotechdb.clientes A
                                                WHERE A.NOME LIKE @CLIENTE)");
                parametros["@CLIENTE"] = "%" + Cliente + "%";
            }

            if (!string.IsNullOrEmpty(Tipo))
            {
                criterioWhere.Add(" A.TIPO LIKE @TIPO ");
                parametros["@TIPO"] = "%" + Tipo + "%";
            }

            if (!criterioWhere.Any())
                return;

            string strCriterioWhere = string.Join(" AND ", criterioWhere);

            CriterioSelecao = new CriterioSelecao(strCriterioWhere, parametros);
        }
    }
}
