using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Models.Tabelas
{
    public class TabelaVeiculo : ITabela
    {
        public string NomeTabela => "veiculos";
        public IDictionary<string, Type> CamposTabela => new Dictionary<string, Type>
        {
            { "Id", typeof(int) },
            { "Nome", typeof(string) },
            { "Ano", typeof(int) },
            { "Tipo", typeof(string) }
        };
    }
}
