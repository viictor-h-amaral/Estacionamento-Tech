
using EstacionamentoTech.Models.Atributos;

namespace EstacionamentoTech.Models
{
    public class HistoricoEstacionamentos : IEntityModel
    {
        public int Id { get; set; }
        public int Veiculo { get; set; }
        public int? Vigencia { get; set; }

        [CampoDetalhe]
        public string? IdentificacaoVeiculo { get; set; }
        [CampoDetalhe]
        public string? Proprietario { get; set; }

        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public decimal? HorasCobradas { get; set; }
        public decimal? ValorCobrado { get; set; }
        public bool Pago { get; set; } = false;
        public string? LogCalculo {  get; set; }
    }
}
