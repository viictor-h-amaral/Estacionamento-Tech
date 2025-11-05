using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;

namespace EstacionamentoTech.MVC.Models.Validadores
{
    public class ClienteValidador : IValidador<Cliente>
    {
        private readonly IContext _contexto;

        public ClienteValidador(IContext context)
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
            if (_contexto.TemDependencias<Cliente>(cliente, new TabelaVeiculo(), "Cliente"))
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
