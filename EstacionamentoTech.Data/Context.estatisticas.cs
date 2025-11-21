using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using MySql.Data.MySqlClient;

namespace EstacionamentoTech.Data
{
    public partial class Context
    {
        public int RetornarMediaEstacionamentosPorCliente(CriterioSelecao? criterioSelecao = null)
        {
            string whereClause = criterioSelecao is null ? "" : $" AND {criterioSelecao.ClausulaWhere} ";
            string strComando = $@"SELECT AVG(D.ESTACIONAMENTOS) 
                                    FROM (
	                                    SELECT COUNT(A.ID) ESTACIONAMENTOS
	                                    FROM {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        INNER JOIN {dataBaseName}.VEICULOS AS B ON A.VEICULO = B.ID
                                        INNER JOIN {dataBaseName}.CLIENTES AS C ON B.CLIENTE = C.ID
                                        WHERE A.SAIDA IS NOT NULL
                                        {whereClause}
                                        GROUP BY C.ID
                                    ) AS D";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                var resultado = comando.ExecuteScalar();
                if (resultado is null || resultado is DBNull)
                    return 0;

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

        public decimal RetornarMediaTempoEfetivoEstacionamentos(CriterioSelecao? criterioSelecao = null)
        {
            string aditionalWhereClause = criterioSelecao is null ? "" : $" AND {criterioSelecao.ClausulaWhere} ";
            string strComando = $@"SELECT AVG(B.DURACAO)
                                    FROM (
                                        SELECT
                                            TIMESTAMPDIFF(MINUTE, A.ENTRADA, A.SAIDA) DURACAO 
                                        FROM 
                                            {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        WHERE A.SAIDA IS NOT NULL
                                        {aditionalWhereClause}
                                    ) AS B";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                var resultado = comando.ExecuteScalar();
                if (resultado is null || resultado is DBNull)
                    return 0m;

                return Convert.ToDecimal(resultado);
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

        public decimal RetornarMediaTempoCobradoEstacionamentos(CriterioSelecao? criterioSelecao = null)
        {
            string aditionalwhereClause = criterioSelecao is null ? "" : $" AND {criterioSelecao.ClausulaWhere} ";
            string strComando = $@"SELECT AVG(B.MINUTOSCOBRADOS)
                                    FROM (
                                        SELECT
                                            (A.HORASCOBRADAS * 60 ) MINUTOSCOBRADOS
                                        FROM 
                                            {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        WHERE A.SAIDA IS NOT NULL
                                        {aditionalwhereClause}
                                    ) AS B";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                var resultado = comando.ExecuteScalar();
                if (resultado is null || resultado is DBNull)
                    return 0m;

                return Convert.ToDecimal(resultado);
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

        public string RetornarClienteComMaiorNumeroDeEstacionamentos(CriterioSelecao? criterioSelecao = null)
        {
            string whereClause = criterioSelecao is null ? "" : $" AND {criterioSelecao.ClausulaWhere} ";
            string strComando = $@"SELECT RANQUEAMENTO_CLIENTES.NOME
                                    FROM (
                                        SELECT 
                                            A.NOME,
                                            COUNT(C.ID) AS QUANTIDADE_ESTACIONAMENTOS,
                                            RANK() OVER (ORDER BY COUNT(C.ID) DESC) AS RANKING
                                        FROM CLIENTES AS A
                                        INNER JOIN VEICULOS AS B ON B.CLIENTE = A.ID
                                        INNER JOIN HISTORICO_ESTACIONAMENTOS AS C ON C.VEICULO = B.ID
                                        WHERE C.SAIDA IS NOT NULL
                                        {whereClause}
                                        GROUP BY A.NOME
                                    ) AS RANQUEAMENTO_CLIENTES
                                    WHERE RANKING = 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                foreach (var parametro in criterioSelecao?.Parametros ?? new Dictionary<string, object?>())
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                var resultado = comando.ExecuteScalar();
                if (resultado is null || resultado is DBNull)
                    return "Nenhum cliente";

                return Convert.ToString(resultado);
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

        public int RetornarQuantidadeEstacionamentosEmAberto()
        {
            return Count<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), new CriterioSelecao("A.SAIDA IS NULL"));
        }

        public int RetornarQuantidadeVeiculosAPagar()
        {
            return Count<HistoricoEstacionamentos>(new TabelaHistoricoEstacionamentos(), new CriterioSelecao("A.PAGO = 0"));
        }
    }
}
