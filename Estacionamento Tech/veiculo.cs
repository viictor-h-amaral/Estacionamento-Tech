using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Estacionamento_Tech
{
    public class Veiculo
    {
        public string placa { get; set; }
        public DateTime horarioEntrada { get; set; }
        public DateTime horarioSaida { get; set; }
        public DateTime duracao { get; set; }
        public decimal horasCobradas { get; set; }
        public decimal reaisPorHora { get; set; }
        public decimal aSerPago { get; set; }

        public static void CadastroEntrada(string novaPlaca, DateTime dataeHorarioEntrada)
        {
            string dataeHorarioEntradaSql = dataeHorarioEntrada.ToString(@"yyyy-MM-dd HH:mm:ss");
            string comandoSql = $"INSERT INTO estacionamentotechdb.veiculos_cadastrados (placa, horarioEntrada) VALUES ('{novaPlaca}', '{dataeHorarioEntradaSql}');";

            try
            {
                using (var conn = new MySqlConnection(Conexao.strConexao))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(comandoSql, conn)) 
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Veículo Cadastrado: Placa {novaPlaca} e Entrada às {dataeHorarioEntrada}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CadastroSaida(string placa, DateTime dataeHorarioSaida, int hoursDuracao, int minutesDuracao, int secondsDuracao, decimal horasCobradas, decimal valorHoraInicial, decimal aSerPago) 
        {
            string dataeHorarioSaidaSql = dataeHorarioSaida.ToString(@"yyyy-MM-dd HH:mm:ss");

            string horasCobradasSql = horasCobradas.ToString().Replace(",",".");
            string valorHoraInicialSql = valorHoraInicial.ToString().Replace(",",".");
            string aSerPagoSql = aSerPago.ToString().Replace(",",".");

            string comandoSql = $"UPDATE estacionamentotechdb.veiculos_cadastrados SET horarioSaida='{dataeHorarioSaidaSql}', duracao='{hoursDuracao}:{minutesDuracao}:{secondsDuracao}', horasCobradas='{horasCobradasSql}', reaisPorHora='{valorHoraInicialSql}', aSerPago='{aSerPagoSql}' WHERE placa='{placa}';";

            try
            {
                using (var conn = new MySqlConnection(Conexao.strConexao))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(comandoSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable PreencheTabelaMenu()
        {
            
            var dataTable = new DataTable();
            string comandoSql = $"SELECT * FROM estacionamentotechdb.veiculos_cadastrados ORDER BY placa;" ;

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

        public static DataTable PreencheCmbPlacaSaida()
        {

            var dt = new DataTable();
            string comandoSql = $" SELECT * FROM estacionamentotechdb.veiculos_cadastrados ORDER BY 'dataEntrada';";

            try
            {
                using (var conn = new MySqlConnection(Conexao.strConexao))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(comandoSql, conn)) //MySqlCommand cria um comando na conexao conn
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DateTime BuscaDataEntrada(string placa)
        {
            var dataEntrada = new DateTime();
            string comandoSql = $"SELECT horarioEntrada FROM estacionamentotechdb.veiculos_cadastrados WHERE placa='{placa}';";
            try
            {
                using (var conn = new MySqlConnection(Conexao.strConexao))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(comandoSql, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            dataEntrada = reader.GetDateTime("horarioEntrada");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataEntrada;

        }

        public static DataTable PreencheTabelaSaida(string placa)
        {
            var dataTable = new DataTable();
            string comandoSql = $"SELECT * FROM estacionamentotechdb.veiculos_cadastrados WHERE placa='{placa}';";

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
    }
}
