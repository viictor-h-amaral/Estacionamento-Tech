using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EstacionamentoTech.Data
{
    public partial class Context
    {
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

        public T? GetOneOrNull<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel
        {
            string whereClause = criterioWhere is null ? "" : $"WHERE {criterioWhere}";
            string strComando = $@"SELECT * 
                                FROM {dataBaseName}.{tabela.NomeTabela} A
                                {whereClause}
                                LIMIT 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                using (MySqlDataReader leitorDados = comando.ExecuteReader())
                {
                    if (leitorDados.Read())
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
                        return entidade;
                    }
                    return null;
                }
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

        public T GetOne<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel
        {
            string whereClause = criterioWhere is null ? "" : $"WHERE {criterioWhere}";
            string strComando = $@"SELECT * 
                                FROM {dataBaseName}.{tabela.NomeTabela} A
                                {whereClause}
                                LIMIT 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                using (MySqlDataReader leitorDados = comando.ExecuteReader())
                {
                    if (leitorDados.Read())
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
                        return entidade;
                    }
                    throw new Exception("Exceção não esperada! Não encontrado objeto certo no banco de dados");
                }
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
