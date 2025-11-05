using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using NSubstitute;

namespace EstacionamentoTech.TestesUnitarios.ValidadoresTests
{
    [TestFixture]
    public class ClienteValidadorTests
    {
        private IContext _contexto;
        private IValidador<Cliente> _validador;

        private Cliente _cliente;

        [SetUp]
        public void Setup()
        {
            _contexto = Substitute.For<IContext>();
            _validador = new ClienteValidador(_contexto);

            CriarCliente();
        }

        private void CriarCliente() 
        {
            _cliente = new Cliente()
            {
                Id = 0,
                Nome = "Teste"
            };
        }

        [Test]
        public void ClienteComDependencia_NaoPodeSerExcluido()
        {
            //Arrange
            _contexto.TemDependencias<Cliente>(Arg.Any<Cliente>(),
                                               Arg.Any<TabelaVeiculo>(),
                                               Arg.Any<string>()).Returns(true);

            //Act
            var validacao = _validador.ValidarNoDelete(_cliente);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }
    }
}
