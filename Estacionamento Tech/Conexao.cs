using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento_Tech
{
    static class Conexao
    {
        private const string servidor = "localhost";
        private const string bancoDados = "estacionamentotechdb";
        private const string usuario = "root";
        private const string senha = "2275";

        public static string strConexao = $"server={servidor}; User ID={usuario}; database={bancoDados}; password={senha}";
    }
}
