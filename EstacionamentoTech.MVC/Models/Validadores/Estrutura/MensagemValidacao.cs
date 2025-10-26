using EstacionamentoTech.MVC.Models.Validadores.Estrutura.Consistencias;

namespace EstacionamentoTech.MVC.Models.Validadores.Estrutura
{
    public class MensagemValidacao
    {
        public string Mensagem { get; set; }
        public TiposValidacoes Tipo { get; set; }

        public MensagemValidacao(string mensagem, TiposValidacoes tipo)
        {
            Mensagem = mensagem;
            Tipo = tipo;
        }

        public MensagemValidacao(string codigo)
        {
            var consistencia = ConsistenciasReader.ObterConsistenciaPorCodigo(codigo);

            Mensagem = consistencia.Mensagem;
            Tipo = consistencia.Tipo;
        }
    }
}
