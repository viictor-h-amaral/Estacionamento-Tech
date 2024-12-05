using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento_Tech
{

    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();

        Form2 adicionarEntrada = new Form2();

        public Form1()
        {
            InitializeComponent();
            PreencheTabela();
            ConfiguraTabela();
        }

        private void adicionarHorarioEntrada_Click(object sender, EventArgs e) 
        {
            adicionarEntrada.Show();
            this.Hide();
        }

        private void adicionarHorarioSaida_Click(object sender, EventArgs e)
        {
            
            Form3 adiconarSaida = new Form3();
            adiconarSaida.Show();
            this.Hide();
        }

        private void btmBuscaPlaca_Click(object sender, EventArgs e)
        {
            string buscaPlaca = mskBuscaPlaca.Text.Replace(" ","");
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "placa", buscaPlaca);
            tabelaConsulta.DataSource = dt;
        }

        private void PreencheTabela()
        {
            dt = Veiculo.PreencheTabelaMenu();
            tabelaConsulta.DataSource = dt;
        }

        private void btmRefreshConsulta_Click(object sender, EventArgs e)
        {
            PreencheTabela();
            mskBuscaPlaca.Clear();
        }

        private void btmColsutaValores_Click(object sender, EventArgs e)
        {
            Form4 consultaValores = new Form4();
            consultaValores.Show();
        }

        private void ConfiguraTabela()
        {
            tabelaConsulta.DefaultCellStyle.Font = new Font("Artifakt Element", 10);
            tabelaConsulta.ColumnHeadersDefaultCellStyle.Font = new Font("Artifakt Element", 11, FontStyle.Bold);
            tabelaConsulta.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            tabelaConsulta.Columns["aSerPago"].DefaultCellStyle.ForeColor = Color.Red;
            tabelaConsulta.RowHeadersWidth = 25;

            tabelaConsulta.Columns["placa"].HeaderText = "Placa";
            tabelaConsulta.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsulta.Columns["horarioEntrada"].HeaderText = "Horário de Entrada";
            tabelaConsulta.Columns["horarioEntrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["horarioEntrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["horarioEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            tabelaConsulta.Columns["horarioEntrada"].DefaultCellStyle.Font = new Font("Artifakt Element", 9);

            tabelaConsulta.Columns["horarioSaida"].HeaderText = "Horário de Saida";
            tabelaConsulta.Columns["horarioSaida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["horarioSaida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["horarioSaida"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            tabelaConsulta.Columns["horarioSaida"].DefaultCellStyle.Font = new Font("Artifakt Element", 9);

            tabelaConsulta.Columns["duracao"].HeaderText = "Duração";
            tabelaConsulta.Columns["duracao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["duracao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsulta.Columns["horasCobradas"].HeaderText = "Horas Cobradas";
            tabelaConsulta.Columns["horasCobradas"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["horasCobradas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsulta.Columns["reaisPorHora"].HeaderText = "Valor da Hora Inicial [R$]";
            tabelaConsulta.Columns["reaisPorHora"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["reaisPorHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaConsulta.Columns["aSerPago"].HeaderText = "A Pagar [R$]";
            tabelaConsulta.Columns["aSerPago"].DefaultCellStyle.Font = new Font("Artifakt Element", 10, FontStyle.Bold);
            tabelaConsulta.Columns["aSerPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaConsulta.Columns["aSerPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
    }
}
