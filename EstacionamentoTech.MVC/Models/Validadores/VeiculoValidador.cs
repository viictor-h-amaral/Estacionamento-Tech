using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using MySqlX.XDevAPI;

namespace EstacionamentoTech.MVC.Models.Validadores
{
    public class VeiculoValidador : IValidador<Veiculo>
    {
        private readonly IContext _contexto;

        public VeiculoValidador(IContext context)
        {
            _contexto = context;
        }

        public MensagemValidacao? ValidarNoCriar(Veiculo veiculo)
        {
            if (ValidarNoSalvar(veiculo) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        public MensagemValidacao? ValidarNoDelete(Veiculo veiculo)
        {
            if (_contexto.TemDependencias(veiculo, new TabelaHistoricoEstacionamentos(), "Veiculo"))
                return new MensagemValidacao("VEI_001");

            return null;
        }

        public MensagemValidacao? ValidarNoEditar(Veiculo veiculo)
        {
            if (ValidarNoSalvar(veiculo) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        private MensagemValidacao? ValidarNoSalvar(Veiculo veiculo)
        {
            return null;
        }
    }
}
