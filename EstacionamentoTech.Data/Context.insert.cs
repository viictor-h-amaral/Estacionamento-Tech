using System.Reflection.Metadata.Ecma335;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Atributos;
using EstacionamentoTech.Models.Tabelas;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EstacionamentoTech.Data
{
    public partial class Context : IContext
    {
        private MySqlConnection _connection;
        private readonly string dataBaseName = "estacionamentotechdb";
        public Context() 
        {
            _connection = new MySqlConnection(Conexao.strConexao);
        }

        public void Insert(ITabela tabela, IEntityModel registro) 
        {
            IEnumerable<string> listaCampos = tabela.CamposTabela.Keys
                                                            .Where(c =>
                                                                !c.Equals("id", StringComparison.CurrentCultureIgnoreCase)
                                                                && registro.GetType()
                                                                            .GetProperty(c)?
                                                                            .GetValue(registro) != null);

            var parametros = new Dictionary<string, object?>();
            var valuesClause = new List<string>();

            foreach (string campo in listaCampos)
            {
                var parametroNome = GerarParametro(campo);
                object? valorCampo = registro.GetType().GetProperty(campo)?.GetValue(registro);
                parametros[parametroNome] = valorCampo;

                valuesClause.Add(parametroNome);
            }

            string strComando = $@"INSERT INTO 
                                {dataBaseName}.{tabela.NomeTabela}({string.Join(", ", listaCampos)})
                                VALUES ({string.Join(", ", valuesClause)})";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

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
            IEnumerable<string> campos = tabela.CamposTabela
                                                .Keys
                                                .Where(c => registro
                                                                .GetType()
                                                                .GetProperty(c)?
                                                                .GetValue(registro) != null);

            var parametros = new Dictionary<string, object?>();
            var setClause = new List<string>();

            foreach (string campo in campos)
            {
                string parametroNome = GerarParametro(campo);
                object? valorCampo = registro.GetType().GetProperty(campo)?.GetValue(registro);
                parametros[parametroNome] = valorCampo;

                setClause.Add($"{campo} = {parametroNome}");
            }

            string strComando = $@"UPDATE {dataBaseName}.{tabela.NomeTabela}
                                   SET {string.Join(", ", setClause)}
                                   WHERE ID = @ID";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

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

        private string GerarParametro(string campo)
        {
            return "@" + campo.ToUpper();
        }

    }
}
