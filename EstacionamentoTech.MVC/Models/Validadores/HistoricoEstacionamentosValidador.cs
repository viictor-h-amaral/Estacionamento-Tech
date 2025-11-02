using EstacionamentoTech.Data;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;

namespace EstacionamentoTech.MVC.Models.Validadores
{
    public class HistoricoEstacionamentosValidador : IValidador<HistoricoEstacionamentos>
    {
        private readonly IContext _contexto;

        public HistoricoEstacionamentosValidador(IContext context)
        {
            _contexto = context;
        }

        public MensagemValidacao? ValidarNoCriar(HistoricoEstacionamentos estacionamento)
        {
            if (ValidarNoSalvar(estacionamento) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        public MensagemValidacao? ValidarNoDelete(HistoricoEstacionamentos estacionamento)
        {
            if (estacionamento.Pago)
                return new MensagemValidacao("EST_003");

            return null;
        }

        public MensagemValidacao? ValidarNoEditar(HistoricoEstacionamentos estacionamento)
        {
            if (ValidarNoSalvar(estacionamento) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        private MensagemValidacao? ValidarNoSalvar(HistoricoEstacionamentos estacionamento)
        {
            if (estacionamento.Entrada > DateTime.Now)
                return new MensagemValidacao("EST_001");

            var criterio = new CriterioSelecao(
                                    @" ID <> @ID
                                       AND VEICULO = @VEICULO 
                                       AND 
                                       (
                                            (SAIDA >= @ENTRADA OR SAIDA IS NULL) 
                                            AND 
                                            (@SAIDA >= ENTRADA OR @SAIDA IS NULL)   
                                       )",
                                    new Dictionary<string, object?>()
                                    {
                                        { "@VEICULO", estacionamento.Veiculo },
                                        { "@ENTRADA", estacionamento.Entrada },
                                        { "@SAIDA", estacionamento.Saida },
                                        { "@ID", estacionamento.Id }
                                    }
                                 );

            if (_contexto.Exists(new TabelaHistoricoEstacionamentos(), criterio))
                return new MensagemValidacao("EST_002");

            return null;
        }

        public MensagemValidacao? ValidarNoFechar(HistoricoEstacionamentos estacionamento)
        {
            if (estacionamento.Saida is null)
                return new MensagemValidacao("EST_004");

            if (estacionamento.Entrada > estacionamento.Saida.Value)
                return new MensagemValidacao("EST_006");

            var criterioSelecaoValores = new CriterioSelecao(
                                        @" ( DATAINICIO <= @SAIDA )
                                           AND 
                                           ( @ENTRADA <= DATAFIM OR DATAFIM IS NULL) ",
                                        new Dictionary<string, object?>()
                                        {
                                            { "@ENTRADA", estacionamento.Entrada },
                                            { "@SAIDA", estacionamento.Saida }
                                        });

            var existeAbrangencia = _contexto.Exists(new TabelaTabelaValores(),
                                                        criterioSelecaoValores);

            if (!existeAbrangencia)
                return new MensagemValidacao("EST_005");

            if (ValidarNoEditar(estacionamento) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }
    }
}
