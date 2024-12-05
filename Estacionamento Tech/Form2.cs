using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Estacionamento_Tech
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btmSalvarEntrada_Click(object sender, EventArgs e)
        {

            bool verificaData;
            bool verificaHora;

            DateTime novoHorario = new DateTime();
            DateTime novaData = new DateTime();
            string novaPlaca = mskPlacaEntrada.Text.Replace(" ", "");

            verificaHora = DateTime.TryParse(mskHoraEntrada.Text, out novoHorario); //verifica se o que fora escrito em mskHoraEntrada é to tipo DateTime
            verificaData = DateTime.TryParse(mskDataEntrada.Text, out novaData); //verifica se o que fora escrito em mskHoraEntrada é to tipo DateTime

            if (novaPlaca.Length < 7) //caso o que fora escrito tenha menos de 7 caracteres ocorre erro
            {
                MessageBox.Show("Placa Informada é Inválida.");
                return;
            }
            else if (verificaHora == false)
            {
                MessageBox.Show("Horário informado é Inválido.");
                return;
            }
            else if (verificaData == false)
            {
                MessageBox.Show("Data informada é Inválida.");
                return;
            }

            DateTime novaDataeHorario = new DateTime(novaData.Year, novaData.Month, novaData.Day, novoHorario.Hour, novoHorario.Minute, novoHorario.Second);
            //DateTime novaDataeHorarioSql = DateTime.Parse(novaDataeHorario.ToString("yyyy/MM/dd HH:mm:ss"));
            Veiculo.CadastroEntrada(novaPlaca, novaDataeHorario);

            mskPlacaEntrada.Clear();
            mskHoraEntrada.Clear();
            mskDataEntrada.Clear();

            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private void btmRelogioEntrada_Click(object sender, EventArgs e)
        {
            mskHoraEntrada.Text = DateTime.Now.ToString("HH:mm:ss");
            mskDataEntrada.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btmVoltarEntrada_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }
    }
}
