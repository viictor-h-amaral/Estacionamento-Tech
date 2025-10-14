
namespace EstacionamentoTech.Models
{
    public class Veiculo : IEntityModel
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
    }
}
