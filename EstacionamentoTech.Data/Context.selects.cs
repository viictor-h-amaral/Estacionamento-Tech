using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EstacionamentoTech.Data
{
    public partial class Context
    {
        public IEnumerable<T> GetMany<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel
        {
            var listaEntidades = new List<T>();

            string whereClause = string.IsNullOrEmpty(criterioWhere) ? "" : $"WHERE {criterioWhere}";
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

        public T? GetOneOrNull<T>(ITabela tabela, CriterioSelecao criterio) where T : class, IEntityModel
        {
            string strComando = $@"SELECT * 
                                FROM {dataBaseName}.{tabela.NomeTabela} A
                                WHERE {criterio.ClausulaWhere}
                                LIMIT 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterio.Parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

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

        public T GetOne<T>(ITabela tabela, CriterioSelecao criterio) where T : class, IEntityModel
        {
            string strComando = $@"SELECT * 
                                FROM {dataBaseName}.{tabela.NomeTabela} A
                                WHERE {criterio.ClausulaWhere}
                                LIMIT 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterio.Parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

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

        public bool Exists(ITabela tabela, CriterioSelecao criterio)
        {
            string strComando = $@"SELECT 1 
                                    FROM {dataBaseName}.{tabela.NomeTabela} 
                                    WHERE {criterio.ClausulaWhere}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);
                
                foreach (var parametro in criterio.Parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                return comando.ExecuteReader().HasRows;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<T> GetManyComPaginacao<T>(ITabela tabela, 
                                                    int offSet = 0, 
                                                    int limit = 10, 
                                                    CriterioSelecao? criterioSelecao = null) where T : class, IEntityModel
        {
            var listaEntidades = new List<T>();

            string whereClause = criterioSelecao == null ? string.Empty : $"WHERE {criterioSelecao.ClausulaWhere}";
            string strComando = $@"SELECT * 
                        FROM {dataBaseName}.{tabela.NomeTabela} A
                        {whereClause}
                        LIMIT {limit} 
                        OFFSET {offSet}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

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

        public int Count<T>(ITabela tabela, CriterioSelecao? criterioSelecao = null) where T : class, IEntityModel
        {
            string whereClause = criterioSelecao == null ? string.Empty : $"WHERE {criterioSelecao.ClausulaWhere}";
            string strComando = $@" SELECT COUNT(*) 
                                    FROM {dataBaseName}.{tabela.NomeTabela} A
                                    {whereClause}";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach(var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                var resultado = comando.ExecuteScalar();
                return Convert.ToInt32(resultado);
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
