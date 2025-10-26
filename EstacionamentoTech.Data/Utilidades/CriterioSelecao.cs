using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Data.Utilidades
{
    public class CriterioSelecao
    {
        private string _clausulaWhere;
        public string ClausulaWhere
        {
            get => _clausulaWhere;
            set 
            {
                _clausulaWhere = value;
            }
        }

        private IDictionary<string, object?> _parametros;
        public IDictionary<string, object?> Parametros { get; set; }

        public CriterioSelecao(string clausulaWhere, IDictionary<string, object?> parametros) 
        {
            ClausulaWhere = clausulaWhere;
            Parametros = parametros;
        }

        public CriterioSelecao(string clausulaWhere)
        {
            ClausulaWhere = clausulaWhere;
            Parametros = new Dictionary<string, object?>();
        }

        public void AdicionarParametro(string nomeVariavel, object? valor)
        {
            Parametros[nomeVariavel] = valor;
        }
    }
}
