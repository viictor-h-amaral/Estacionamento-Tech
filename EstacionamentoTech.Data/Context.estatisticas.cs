using MySql.Data.MySqlClient;

namespace EstacionamentoTech.Data
{
    public partial class Context
    {
        public long RetornarMediaEstacionamentosPorCliente()
        {
            string strComando = $@"SELECT AVG(D.ESTACIONAMENTOS) 
                                    FROM (
	                                    SELECT COUNT(A.ID) ESTACIONAMENTOS
	                                    FROM {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        INNER JOIN {dataBaseName}.VEICULOS AS B ON A.VEICULO = B.ID
                                        INNER JOIN {dataBaseName}.CLIENTES AS C ON B.CLIENTE = C.ID
                                        WHERE A.ENTRADA >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                        GROUP BY C.ID
                                    ) AS D";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

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

        public decimal RetornarMediaTempoEfetivoEstacionamentos()
        {
            string strComando = $@"SELECT AVG(B.DURACAO)
                                    FROM (
                                        SELECT
                                            TIMESTAMPDIFF(MINUTE, A.ENTRADA, A.SAIDA) DURACAO 
                                        FROM 
                                            {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        WHERE 
                                            A.SAIDA IS NOT NULL
                                            AND A.ENTRADA >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                    ) AS B";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                var resultado = comando.ExecuteScalar();
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

        public decimal RetornarMediaTempoCobradoEstacionamentos()
        {
            string strComando = $@"SELECT AVG(B.MINUTOSCOBRADOS)
                                    FROM (
                                        SELECT
                                            (A.HORASCOBRADAS * 60 ) MINUTOSCOBRADOS
                                        FROM 
                                            {dataBaseName}.HISTORICO_ESTACIONAMENTOS AS A
                                        WHERE 
                                            A.SAIDA IS NOT NULL
                                            AND A.ENTRADA >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                    ) AS B";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                var resultado = comando.ExecuteScalar();
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

        public string RetornarClienteComMaiorNumeroDeEstacionamentos()
        {
            string strComando = $@"SELECT RANQUEAMENTO_CLIENTES.NOME
                                    FROM (
                                        SELECT 
                                            A.NOME,
                                            COUNT(C.ID) AS QUANTIDADE_ESTACIONAMENTOS,
                                            RANK() OVER (ORDER BY COUNT(C.ID) DESC) AS RANKING
                                        FROM CLIENTES AS A
                                        INNER JOIN VEICULOS AS B ON B.CLIENTE = A.ID
                                        INNER JOIN HISTORICO_ESTACIONAMENTOS AS C ON C.VEICULO = B.ID
                                        WHERE C.ENTRADA >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                        GROUP BY A.NOME
                                    ) AS RANQUEAMENTO_CLIENTES
                                    WHERE RANKING = 1";

            try
            {
                _connection.Open();
                var comando = new MySqlCommand(strComando, _connection);

                var resultado = comando.ExecuteScalar();
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
    }
}
