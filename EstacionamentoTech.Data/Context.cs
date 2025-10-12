using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EstacionamentoTech.Data
{
    public class Context
    {
        private MySqlConnection _connection;
        private string dataBaseName = "estacionamentotechdb";
        public Context() 
        {
            _connection = new MySqlConnection(Conexao.strConexao);
        }

        public IEnumerable<T> GetMany<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel
        {
            var listaEntidades = new List<T>();

            string whereClause = criterioWhere is null ? "" : $"WHERE {criterioWhere}";
            string strComando = $@"SELECT * 
                                FROM {dataBaseName}.{tabela.NomeTabela} A
                                {whereClause}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                using (MySqlDataReader leitorDados = comando.ExecuteReader())
                {
                    while (leitorDados.Read())
                    {
                        T entidade = Activator.CreateInstance<T>();
                        foreach (var campo in tabela.CamposTabela)
                        {
                            var valor = leitorDados[campo.Key];
                            if (valor != DBNull.Value)
                            {
                                entidade.GetType().GetProperty(campo.Key)?.SetValue(entidade, Convert.ChangeType(valor, campo.Value));
                            }
                        }
                        listaEntidades.Add(entidade);
                    }
                }
                return listaEntidades;
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

        public void Insert(ITabela tabela, IEntityModel registro) 
        {
            string campos = string.Join(", ", tabela.CamposTabela.Keys  
                                                            .Where(c =>
                                                                !c.Equals("id", StringComparison.CurrentCultureIgnoreCase)
                                                                && registro.GetType()
                                                                            .GetProperty(c)?
                                                                            .GetValue(registro) != null));

            string values = string.Join(", ", tabela.CamposTabela.Keys
                                                            .Where(c =>
                                                                !c.Equals("id", StringComparison.CurrentCultureIgnoreCase)
                                                                && registro.GetType()
                                                                            .GetProperty(c)?
                                                                            .GetValue(registro) != null)
                                                            .Select(c => 
                                                            {
                                                                var valor = registro.GetType().GetProperty(c)?.GetValue(registro);
                                                                return ObjetoParaStringConversor
                                                                        .ConverterParaString(valor);
                                                            })
                                       );

            string strComando = $@"INSERT INTO 
                                {dataBaseName}.{tabela.NomeTabela}({campos})
                                VALUES ({values})";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);
                comando.ExecuteNonQuery();
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

        public void Update(ITabela tabela, IEntityModel registro)
        {
            IDictionary<string, string> campoValor = new Dictionary<string, string>();

            IList<string> campos = tabela.CamposTabela.Keys.Where(c =>
                                                                    !c.Equals("id", StringComparison.CurrentCultureIgnoreCase)
                                                                        && 
                                                                    registro
                                                                        .GetType()
                                                                        .GetProperty(c)?
                                                                        .GetValue(registro) != null
                                                                )
                                                            .ToList();
            foreach (string campo in campos)
            {
                string valor = ObjetoParaStringConversor
                                .ConverterParaString(registro
                                                        .GetType()
                                                        .GetProperty(campo)?
                                                        .GetValue(registro));
                campoValor.Add(campo, valor);
            }

            string strComando = $@"UPDATE  
                                {dataBaseName}.{tabela.NomeTabela}
                                SET {
                                        string.Join(", ", campoValor.Keys.Select(c => $"{c} = {campoValor[c]}") )
                                    }
                                WHERE Id = {registro.Id}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);
                comando.ExecuteNonQuery();
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
    }
}
