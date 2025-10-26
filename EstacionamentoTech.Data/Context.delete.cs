using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EstacionamentoTech.Data
{
    public partial class Context
    {
        public bool Delete<T>(ITabela tabela, T registro) where T : class, IEntityModel
        {
            string strComando = $@" DELETE 
                                    FROM {dataBaseName}.{tabela.NomeTabela} A
                                    WHERE A.Id = {registro.Id}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool TemDependencias<T>(T registro, ITabela tabelaDependencia, string colunaFk) where T : class, IEntityModel
        {
            string strComando = $@"SELECT 1 
                                    FROM {dataBaseName}.{tabelaDependencia.NomeTabela} 
                                    WHERE {colunaFk} = {registro.Id}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);
                return comando.ExecuteReader().HasRows;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
