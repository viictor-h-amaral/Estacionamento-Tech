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
            { "dataInicio", typeof(string) },
            { "dataFim", typeof(int) },
            { "valorHoraInicial", typeof(string) },
            { "valorHoraAdicional", typeof(string) }
        };
    }
}
