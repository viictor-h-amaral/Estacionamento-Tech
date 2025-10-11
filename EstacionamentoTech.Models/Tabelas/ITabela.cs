using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Models.Tabelas
{
    public interface ITabela
    {
        public string NomeTabela { get; }
        public IDictionary<string, Type> CamposTabela { get; }
    }
}
