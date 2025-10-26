using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Models.Tabelas
{
    public class TabelaClientes : ITabela
    {
        public string NomeTabela => "clientes";
        public IDictionary<string, Type> CamposTabela => new Dictionary<string, Type>
        {
            { "Id", typeof(int) },
            { "Nome", typeof(string) }
        };
    }
}
