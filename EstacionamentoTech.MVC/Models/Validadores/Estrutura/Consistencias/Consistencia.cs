using EstacionamentoTech.MVC.Models.Validadores.Estrutura;

namespace EstacionamentoTech.MVC.Models.Validadores.Estrutura.Consistencias
{
    public class Consistencia
    {
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
        public TiposValidacoes Tipo { get; set; }
    }
}
