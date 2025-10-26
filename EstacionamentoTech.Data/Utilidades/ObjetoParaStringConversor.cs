using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoTech.Data.Utilidades
{
    public static class ObjetoParaStringConversor
    {
        public static string ConverterParaString(object? valor = null)
        {
            if (valor is null)
                return "NULL";

            if (valor is string S)
                return $"'{S}'";

            else if (valor is DateTime Dt)
                return $"'{Dt:yyyy-MM-dd HH:mm:ss}'";

            else if (valor is bool B)
                return B ? "1" : "0";

            else if (valor is int I)
                return I.ToString();

            else if (valor is decimal De)
                return De.ToString("F2").Replace(",", ".") ?? "NULL";

            else if (valor is Enum)
                return Convert.ToInt32(valor).ToString();

            else
                return valor?.ToString() ?? "NULL";
        }
    }
}
