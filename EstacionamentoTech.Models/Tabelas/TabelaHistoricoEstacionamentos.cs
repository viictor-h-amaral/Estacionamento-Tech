using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Models.Tabelas
{
    public class TabelaHistoricoEstacionamentos : ITabela
    {
        public string NomeTabela => "historico_estacionamentos";
        public IDictionary<string, Type> CamposTabela => new Dictionary<string, Type>
        {
            { "Id", typeof(int) },
            { "Veiculo", typeof(int) },
            { "Vigencia", typeof(int) },
            { "Entrada", typeof(DateTime) },
            { "Saida", typeof(DateTime) },
            { "HorasCobradas", typeof(decimal) },
            { "ValorCobrado", typeof(decimal) },
            { "Pago", typeof(bool) },
            { "LogCalculo", typeof(string) }
        };
    }
}
