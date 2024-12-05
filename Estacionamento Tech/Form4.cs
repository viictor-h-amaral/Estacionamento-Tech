using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento_Tech
{
    public partial class Form4 : Form
    {
        DataTable dt = new DataTable();

        public Form4()
        {
            InitializeComponent();
            preencheTabelaValores();
            ConfiguraTabela();
        }

        public void preencheTabelaValores()
        {
            dt = ConsultaValores.preencheTabelaValores();
            tabelaValores.DataSource = dt;
        }

        public void ConfiguraTabela()
        {
            tabelaValores.DefaultCellStyle.Font = new Font("Artifakt Element", 9);
            tabelaValores.ColumnHeadersDefaultCellStyle.Font = new Font("Artifakt Element", 12, FontStyle.Bold);
            tabelaValores.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            tabelaValores.RowHeadersWidth = 25;

            tabelaValores.Columns["dataInicio"].HeaderText = "Início da Vigência";
            tabelaValores.Columns["dataInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["dataInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["dataInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            tabelaValores.Columns["dataFim"].HeaderText = "Fim da Vigência";
            tabelaValores.Columns["dataFim"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["dataFim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["dataFim"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            tabelaValores.Columns["valorHoraInicial"].HeaderText = "Valor da Hora Inicial [R$]";
            tabelaValores.Columns["valorHoraInicial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["valorHoraInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabelaValores.Columns["valorHoraAdicional"].HeaderText = "Valor da Hora Adicional [R$]";
            tabelaValores.Columns["valorHoraAdicional"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabelaValores.Columns["valorHoraAdicional"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
    }
}
