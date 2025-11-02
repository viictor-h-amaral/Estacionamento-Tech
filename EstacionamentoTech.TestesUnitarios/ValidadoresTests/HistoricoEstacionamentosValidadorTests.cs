using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using NSubstitute;
using NUnit.Framework;

namespace EstacionamentoTech.TestesUnitarios.ValidadoresTests
{
    [TestFixture]
    public class HistoricoEstacionamentosValidadorTests
    {
        private IContext _contexto;
        private HistoricoEstacionamentosValidador _validador;

        [SetUp]
        public void Setup()
        {
            _contexto = Substitute.For<IContext>();
            _validador = new HistoricoEstacionamentosValidador(_contexto);
        }

        [Test]
        public void EstacionamentoSemSaida_NaoDeveSerFechado()
        {
            //Arrange
            var estacionamentoInvalido = new HistoricoEstacionamentos()
            {
                Id = 0,
                Veiculo = 0,
                Entrada = new DateTime(2025, 11, 02),
                Saida = null,
                Pago = false
            };

            //Act
            var validacao = _validador.ValidarNoFechar(estacionamentoInvalido);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }

        [Test]
        public void EstacionamentoComInicioPosterioAoFim_NaoDeveSerFechado()
        {
            //Arrange
            var estacionamentoInvalido = new HistoricoEstacionamentos()
            {
                Id = 0,
                Veiculo = 0,
                Entrada = new DateTime(2025, 11, 02),
                Saida = new DateTime(2025, 11, 01),
                Pago = false
            };

            //Act
            var validacao = _validador.ValidarNoFechar(estacionamentoInvalido);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }

        [Test]
        public void EstacionamentoComInicioPosterioADataCorrente_NaoDeveSerSalvo()
        {
            //Arrange
            var estacionamentoInvalido = new HistoricoEstacionamentos()
            {
                Id = 0,
                Veiculo = 0,
                Entrada = DateTime.Now.AddDays(1),
                Pago = false
            };

            //Act
            var validacao1 = _validador.ValidarNoCriar(estacionamentoInvalido);
            var validacao2 = _validador.ValidarNoEditar(estacionamentoInvalido);

            //Assert
            Assert.That(validacao1, Is.Not.Null);
            Assert.That(validacao2, Is.Not.Null);
        }
    }
}
