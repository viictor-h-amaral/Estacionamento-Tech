using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;

namespace EstacionamentoTech.MVC.Models.Validadores
{
    internal class ClienteValidator : IValidador<Cliente>
    {
        private readonly Context _contexto;

        public ClienteValidator(Context context)
        {
            _contexto = context;
        }

        public MensagemValidacao? ValidarNoCriar(Cliente cliente)
        {
            if (ValidarNoSalvar(cliente) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        public MensagemValidacao? ValidarNoDelete(Cliente cliente)
        {
            if (_contexto.TemDependencias(cliente, new TabelaVeiculo(), "Cliente"))
                return new MensagemValidacao("CLI_001");

            return null;
        }

        public MensagemValidacao? ValidarNoEditar(Cliente cliente)
        {
            if (ValidarNoSalvar(cliente) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        private MensagemValidacao? ValidarNoSalvar(Cliente cliente)
        {
            return null;
        }
    }
}
