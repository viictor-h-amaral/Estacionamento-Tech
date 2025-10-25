using System.Text;
using EstacionamentoTech.Data;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;

namespace EstacionamentoTech.MVC.Models
{
    public class HistoricoEstacionamentosExtensor
    {
        private HistoricoEstacionamentos _estacionamento;
        public HistoricoEstacionamentos Estacionamento {
            get => _estacionamento; 
            set => _estacionamento = value; 
        }

        private TabelaValores? _vigenciaInstance;
        public TabelaValores? VigenciaInstance
        {
            get => _vigenciaInstance;
            set 
            { 
                if (value != null)
                {
                    _vigenciaInstance = value;
                    Estacionamento.Vigencia = value.Id;
                }
            }
        }

        private readonly Context _contexto;

        public HistoricoEstacionamentosExtensor(Context contexto, HistoricoEstacionamentos estacionamento)
        {
            Estacionamento = estacionamento;
            _contexto = contexto;
        }

        public void CalcularHorasCobradas()
        {
            var logCalculo = new StringBuilder();

            var saida = Estacionamento.Saida.Value;
            var entrada = Estacionamento.Entrada;

            TimeSpan duracao = saida - entrada;

            decimal horasCobradas;

            if (duracao.TotalMinutes <= 30)
                horasCobradas = 0.5m;

            else if (duracao.Minutes <= 10)
                horasCobradas = Math.Floor((decimal)duracao.TotalHours);

            else
                horasCobradas = Math.Ceiling((decimal)duracao.TotalHours);

            logCalculo.AppendLine($"{duracao.Hours}h{duracao.Minutes}min estacionados >> {(horasCobradas > 1 ? $"{horasCobradas}h cobradas" : $"{horasCobradas*60}min cobrados")}.");
            
            Estacionamento.HorasCobradas = horasCobradas;
            Estacionamento.LogCalculo += logCalculo.ToString();
        }

        public void DefinirVigencia()
        {
            var criterioSelecaoValores = new CriterioSelecao(
                                        @" ( DATAINICIO <= @SAIDA )
                                           AND 
                                           ( @ENTRADA <= DATAFIM OR DATAFIM IS NULL) ",
                                        new Dictionary<string, object?>()
                                        {
                                            { "@ENTRADA", Estacionamento.Entrada },
                                            { "@SAIDA", Estacionamento.Saida }
                                        });

            VigenciaInstance = _contexto.GetOne<TabelaValores>(new TabelaTabelaValores(),
                                                                criterioSelecaoValores);

            var logCalculo = new StringBuilder();
            
            if (VigenciaInstance.DataFim.HasValue)
            {
                logCalculo.AppendLine($"Vigência de {VigenciaInstance.DataInicio.ToString("dd/MM/yyyy")} a {VigenciaInstance.DataFim.Value.ToString("dd/MM/yyyy")} (id{VigenciaInstance.Id})");
            }
            else
            {
                logCalculo.AppendLine($"Vigência de {VigenciaInstance.DataInicio.ToString("dd/MM/yyyy")} até data de saída do veículo, {Estacionamento.Saida.Value.ToString("dd/MM/yyyy")} (id{VigenciaInstance.Id})");
            }

            Estacionamento.LogCalculo += "\n" + logCalculo.ToString();
        }

        public void CalcularValorCobrado()
        {
            if (VigenciaInstance is null || !Estacionamento.Vigencia.HasValue)
                return;

            var logCalculo = new StringBuilder();

            decimal valorHoraInicial = VigenciaInstance.ValorHoraInicial;
            logCalculo.AppendLine($"Hora inicial = R${VigenciaInstance.ValorHoraInicial}");

            decimal valorHoraAdicional = VigenciaInstance.ValorHoraAdicional;
            logCalculo.AppendLine($"Hora adicional = R${VigenciaInstance.ValorHoraAdicional}");

            decimal horasCobradas = Estacionamento.HorasCobradas.Value;

            decimal aSerPago;

            if (horasCobradas < 1)
            {
                aSerPago = valorHoraInicial * horasCobradas;
                logCalculo.AppendLine($"Total a pagar = {horasCobradas}h * R${valorHoraInicial}/h = R${aSerPago}");
            }
            else
            {
                aSerPago = valorHoraInicial + (horasCobradas - 1) * valorHoraAdicional;
                logCalculo.AppendLine($"Total a pagar = R${valorHoraInicial} + {horasCobradas-1}h * R${valorHoraAdicional}/h");
            }

            Estacionamento.ValorCobrado = aSerPago;
            Estacionamento.LogCalculo += $"\n" + logCalculo.ToString();
        }
    }
}
