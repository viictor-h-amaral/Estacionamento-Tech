
namespace EstacionamentoTech.Models
{
    public class HistoricoEstacionamento : IEntityModel
    {
        

        public int Id { get; set; }

        public int Veiculo { get; set; }
        //public Veiculo VeiculoInstance { get; set; }

        public int Cliente { get; set; }
        /*public Cliente ClienteInstance 
        { 
            get => Context.GetEntity<Cliente>(id:Id);
            set => Cliente = value.Id;
        }*/

        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public decimal ValorCobrado { get; set; }
        public bool Pago { get; set; }
    }
}
