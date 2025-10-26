using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Models.Tabelas
{
    public class TabelaTabelaValores : ITabela
    {
        public string NomeTabela => "tabela_valores";
        public IDictionary<string, Type> CamposTabela => new Dictionary<string, Type>
        {
            { "Id", typeof(int) },
            { "DataInicio", typeof(DateTime) },
            { "DataFim", typeof(DateTime) },
            { "ValorHoraInicial", typeof(decimal) },
            { "ValorHoraAdicional", typeof(decimal) }
        };
    }
}
