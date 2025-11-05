using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using NSubstitute;

namespace EstacionamentoTech.TestesUnitarios.ValidadoresTests
{
    [TestFixture]
    public class VeiculoValidadorTests
    {
        private IContext _contexto;
        private IValidador<Veiculo> _validador;

        private readonly Veiculo _veiculoPadrao = new Veiculo()
        {
            Id = 0,
            Cliente = 0,
            Placa = "ABC1234"
        };

        [SetUp]
        public void Setup()
        {
            _contexto = Substitute.For<IContext>();
            _validador = new VeiculoValidador(_contexto);
        }

        [Test]
        public void VeiculoComDependecia_NaoPodeSerExcluido()
        {
            //Arrange
            _contexto.TemDependencias<Veiculo>(Arg.Any<Veiculo>(),
                                                Arg.Any<TabelaHistoricoEstacionamentos>(),
                                                Arg.Any<string>()).Returns(true);

            //Act
            var validacao = _validador.ValidarNoDelete(_veiculoPadrao);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }
    }
}
