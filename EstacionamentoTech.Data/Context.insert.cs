using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
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

            string campos = string.Join(", ", listaCampos);

            string values = string.Join(", ", listaCampos
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
