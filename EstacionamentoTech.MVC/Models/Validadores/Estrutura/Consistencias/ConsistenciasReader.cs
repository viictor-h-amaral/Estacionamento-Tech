using System.Text.Json;

namespace EstacionamentoTech.MVC.Models.Validadores.Estrutura.Consistencias
{
    public static class ConsistenciasReader
    {
        public static IEnumerable<Consistencia> CarregarConsistencias()
        {
            string arquivoConsistencias = "Models/Validadores/Estrutura/Consistencias/Consistencias.json";

            try
            {
                string jsonString = File.ReadAllText(arquivoConsistencias);

                var consistencias = JsonSerializer.Deserialize<IEnumerable<Consistencia>>(jsonString);

                return consistencias;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao carregar as consistências.", ex);
            }
        }

        public static Consistencia ObterConsistenciaPorCodigo(string codigo)
        {
            var consistencias = CarregarConsistencias();
            return consistencias?.FirstOrDefault(c => c.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Consistência de código {codigo} não encontrado.");
        }
    }
}
