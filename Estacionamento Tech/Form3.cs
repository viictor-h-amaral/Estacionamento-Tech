using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento_Tech
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            PreencheCmbPlacaSaida();
        }

        DataTable dt = new DataTable();

        private void btmSalvarSaida_Click(object sender, EventArgs e)
        {

            bool verificaData = false;
            bool verificaHora = false;
            var horarioSaida = new DateTime();
            var dataSaida = new DateTime();
            string placa = cmbPlacaSaida.Text;
            //
            //Verificação
            //
            verificaHora = DateTime.TryParse(mskHoraSaida.Text, out horarioSaida); //verifica se o que fora escrito em mskHoraEntrada é to tipo DateTime
            verificaData = DateTime.TryParse(mskDataSaida.Text, out dataSaida); //verifica se o que fora escrito em mskHoraEntrada é to tipo DateTime
            if (placa.Length == 0) //caso o usuário não tenha selecionado uma placa
            {
                MessageBox.Show("Selecione Corretamente a Placa.");
                return;
            }
            else if (verificaHora == false) //caso não, ocorre erro
            {
                MessageBox.Show("Horário informado é Inválido.");
                return;
            }
            else if (verificaData == false) //caso não, ocorre erro
            {
                MessageBox.Show("Data informada é Inválida.");
                return;
            }
            //
            //calculo do Pagamento;
            //
            DateTime dataeHorarioSaida = new DateTime(dataSaida.Year, dataSaida.Month, dataSaida.Day, horarioSaida.Hour, horarioSaida.Minute, horarioSaida.Second);
            DateTime dataeHorarioEntrada = Veiculo.BuscaDataEntrada(placa);
            TimeSpan duracao = dataeHorarioSaida - dataeHorarioEntrada;

            Decimal valorHoraInicial = ConsultaValores.PegaValores(dataeHorarioEntrada).Item1;
            Decimal valorHoraAdicional = ConsultaValores.PegaValores(dataeHorarioEntrada).Item2;

            Decimal horasCobradas;
            Decimal aSerPago;

            if (duracao.TotalMinutes <= 30)
            {
                horasCobradas = 0.5m;
                aSerPago = valorHoraInicial / 2;
            } 
            else if (duracao.Minutes <= 10){
                horasCobradas = Math.Floor((decimal)duracao.TotalHours);
                aSerPago = 1 * valorHoraInicial + (horasCobradas-1) * valorHoraAdicional;
            }
            else
            {
                horasCobradas = Math.Ceiling((decimal)duracao.TotalHours);
                aSerPago = 1 * valorHoraInicial + (horasCobradas - 1) * valorHoraAdicional;
            }
            //
            //cadastro
            //
            int hoursDuracao = duracao.Days * 24 + duracao.Hours;
            int minutesDuracao = duracao.Minutes;
            int secondsDuracao = duracao.Seconds;

            Veiculo.CadastroSaida(placa, dataeHorarioSaida, hoursDuracao, minutesDuracao, secondsDuracao, (decimal)horasCobradas, (decimal)valorHoraInicial, (decimal)aSerPago);
            //
            //Insere dados na tabela
            //
            PreencheTabelaSaida(placa);
            ConfiguraTabelaSaida();
        }

        private void btmRelogioSaida_Click(object sender, EventArgs e)
        {
            mskHoraSaida.Text = DateTime.Now.ToString("HH:mm:ss");
            mskDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btmVoltarSaida_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private void PreencheCmbPlacaSaida()
        {
            cmbPlacaSaida.DataSource = Veiculo.PreencheCmbPlacaSaida();
            cmbPlacaSaida.ValueMember = "Placa";
            cmbPlacaSaida.DisplayMember = "placa";
        }

        private void PreencheTabelaSaida(string placa)
        {
            dt = Veiculo.PreencheTabelaSaida(placa);
            tabelaConsultaSaida.DataSource = dt;
        }

        private void ConfiguraTabelaSaida()
        {
            tabelaConsultaSaida.DefaultCellStyle.Font = new Font("Artifakt Element", 10);
            tabelaConsultaSaida.ColumnHeadersDefaultCellStyle.Font = new Font("Artifakt Element", 11, FontStyle.Bold);
            tabelaConsultaSaida.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            tabelaConsultaSaida.Columns["aSerPago"].DefaultCellStyle.ForeColor = Color.Red;
            tabelaConsultaSaida.RowHeadersWidth = 25;

            tabelaConsultaSaida.Columns["placa"].HeaderText = "Placa";
            tabelaConsultaSaida.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsultaSaida.Columns["horarioEntrada"].HeaderText = "Horário de Entrada";
            tabelaConsultaSaida.Columns["horarioEntrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["horarioEntrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["horarioEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            tabelaConsultaSaida.Columns["horarioEntrada"].DefaultCellStyle.Font = new Font("Artifakt Element", 9);

            tabelaConsultaSaida.Columns["horarioSaida"].HeaderText = "Horário de Saida";
            tabelaConsultaSaida.Columns["horarioSaida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["horarioSaida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["horarioSaida"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            tabelaConsultaSaida.Columns["horarioSaida"].DefaultCellStyle.Font = new Font("Artifakt Element", 9);

            tabelaConsultaSaida.Columns["duracao"].HeaderText = "Duração";
            tabelaConsultaSaida.Columns["duracao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["duracao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsultaSaida.Columns["horasCobradas"].HeaderText = "Horas Cobradas";
            tabelaConsultaSaida.Columns["horasCobradas"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["horasCobradas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsultaSaida.Columns["reaisPorHora"].HeaderText = "Valor da Hora Inicial [R$]";
            tabelaConsultaSaida.Columns["reaisPorHora"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["reaisPorHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsultaSaida.Columns["aSerPago"].HeaderText = "A Pagar [R$]";
            tabelaConsultaSaida.Columns["aSerPago"].DefaultCellStyle.Font = new Font("Artifakt Element", 10, FontStyle.Bold);
            tabelaConsultaSaida.Columns["aSerPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsultaSaida.Columns["aSerPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

    }
}
