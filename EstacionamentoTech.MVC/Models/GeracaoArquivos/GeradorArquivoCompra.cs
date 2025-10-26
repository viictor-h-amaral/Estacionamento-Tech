using System.Text;

namespace EstacionamentoTech.MVC.Models.GeracaoArquivos
{
    public class GeradorArquivoCompra
    {
        private async Task<string> GerarConteudoTxtAsync(ArquivoCompraDataContract estacionamento)
        {
            return await Task.Run(() =>
            {
                var sb = new StringBuilder();
                sb.AppendLine($" ----- ESTACIONAMENTO TECH ----- ");
                sb.AppendLine($" ---- COMPROV. DE PAGAMENTO ---- ");
                sb.AppendLine($"VEÍCULO:                {estacionamento.Veiculo}");
                sb.AppendLine($"PROPRIETÁRIO:           {estacionamento.Proprietario}");
                sb.AppendLine($"ENTRADA:                {estacionamento.Entrada}");
                sb.AppendLine($"SAÍDA:                  {estacionamento.Saida}");
                sb.AppendLine($"VALOR:                  {estacionamento.Valor}");
                sb.AppendLine($"FORMA DE PAGAMENTO:     {estacionamento.FormaPagamento}");
                sb.AppendLine();
                sb.AppendLine($" ---- {estacionamento.Serial} ---- ");

                return sb.ToString();
            });
        }

        public async Task<byte[]> GerarArquivoTxtBytesAsync(ArquivoCompraDataContract estacionamento)
        {
            var conteudo = await GerarConteudoTxtAsync(estacionamento);
            return Encoding.UTF8.GetBytes(conteudo);
        }
    }

    public class ArquivoCompraDataContract
    {
        public string Veiculo { get; set; }
        public string Proprietario { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public Guid Serial { get; set; }
    }
}
