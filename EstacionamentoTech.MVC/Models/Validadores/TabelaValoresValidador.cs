using EstacionamentoTech.Data;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using MySqlX.XDevAPI;

namespace EstacionamentoTech.MVC.Models.Validadores
{
    public class TabelaValoresValidador : IValidador<TabelaValores>
    {
        private readonly Context _contexto;

        public TabelaValoresValidador(Context context)
        {
            _contexto = context;
        }

        public MensagemValidacao? ValidarNoCriar(TabelaValores vigencia)
        {
            if (vigencia.DataInicio >= vigencia.DataFim)
                return new MensagemValidacao("VIG_001");

            var criterio = new CriterioSelecao(@" (@DATAFIM >= DATAINICIO 
                                                     OR
                                                  @DATAFIM IS NULL)
                                                   AND 
                                                  (DATAFIM >= @DATAINICIO 
                                                     OR 
                                                  DATAFIM IS NULL) ");

            criterio.AdicionarParametro("@DATAINICIO", vigencia.DataInicio);
            criterio.AdicionarParametro("@DATAFIM", vigencia.DataFim);

            if (_contexto.Exists(new TabelaTabelaValores(), criterio))
                return new MensagemValidacao("VIG_002");

            if (ValidarNoSalvar(vigencia) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        public MensagemValidacao? ValidarNoDelete(TabelaValores vigencia)
        {
            return null;
        }

        public MensagemValidacao? ValidarNoEditar(TabelaValores vigencia)
        {
            if (ValidarNoSalvar(vigencia) is MensagemValidacao mensagem)
                return mensagem;

            return null;
        }

        private MensagemValidacao? ValidarNoSalvar(TabelaValores vigencia)
        {
            return null;
        }
    }
}
