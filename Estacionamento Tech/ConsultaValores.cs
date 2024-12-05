using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Estacionamento_Tech
{
    internal class ConsultaValores
    {
        public static DataTable preencheTabelaValores()
        {
            var dataTable = new DataTable();
            string comandoSql = $"SELECT * FROM estacionamentotechdb.tabela_valores ORDER BY dataInicio;";

            try
            {
                using (var conn = new MySqlConnection(Conexao.strConexao))
                {
                    conn.Open();
                    using (var dataAdapter = new MySqlDataAdapter(comandoSql, conn)) //MySqlDataAdapter cria as linhas e colunas necessárias e converte o necessário para dataAdapter receber
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

        public static (Decimal, Decimal) PegaValores(DateTime dataeHorarioEntrada)
        {
            decimal valorHoraInicial = 4; //valores padrao caso nao seja possivel encontrar em qual intervalo se encontra a data de entrada do veiculo
            decimal valorHoraAdicional = 2;

            

            try
            {
                using (var conn1 = new MySqlConnection(Conexao.strConexao))
                using (var conn2 = new MySqlConnection(Conexao.strConexao))
                using (var conn3 = new MySqlConnection(Conexao.strConexao))
                using (var conn4 = new MySqlConnection(Conexao.strConexao))
                {
                    conn1.Open();
                    conn2.Open();
                    conn3.Open();
                    conn4.Open();

                    MySqlCommand cmdDataInicio = new MySqlCommand($"SELECT dataInicio FROM estacionamentotechdb.tabela_valores;", conn1);
                    MySqlCommand cmdDataFim = new MySqlCommand($"SELECT dataFim FROM estacionamentotechdb.tabela_valores;", conn2);
                    MySqlCommand cmdValorHoraInicial = new MySqlCommand($"SELECT valorHoraInicial FROM estacionamentotechdb.tabela_valores;", conn3);
                    MySqlCommand cmdValorHoraAdicional = new MySqlCommand($"SELECT valorHoraAdicional FROM estacionamentotechdb.tabela_valores;", conn4);

                    using (MySqlDataReader readerDataInicio = cmdDataInicio.ExecuteReader())
                    using (MySqlDataReader readerDataFim = cmdDataFim.ExecuteReader())
                    using (MySqlDataReader readerValorInicial = cmdValorHoraInicial.ExecuteReader())
                    using (MySqlDataReader readerValorAdicional = cmdValorHoraAdicional.ExecuteReader())
                    {

                        while (readerDataInicio.Read())
                        {
                            readerDataFim.Read();
                            readerValorInicial.Read();
                            readerValorAdicional.Read();

                            DateTime dataFim = readerDataFim.GetDateTime("dataFim");
                            DateTime dataInicio = readerDataInicio.GetDateTime("dataInicio");

                            TimeSpan intervaloInicioFim = dataFim - dataInicio;
                            TimeSpan intervaloEntradaInicio = dataeHorarioEntrada - dataInicio;

                            if ((intervaloEntradaInicio.TotalHours > 0) && (intervaloEntradaInicio.TotalHours <= intervaloInicioFim.TotalHours))
                            {
                                valorHoraInicial = readerValorInicial.GetDecimal("valorHoraInicial");
                                valorHoraAdicional = readerValorAdicional.GetDecimal("valorHoraAdicional");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return (valorHoraInicial, valorHoraAdicional);
            
            
        }
    }
}
