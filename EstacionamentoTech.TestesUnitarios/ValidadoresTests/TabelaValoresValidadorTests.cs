using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;
using EstacionamentoTech.MVC.Models.Validadores;
using EstacionamentoTech.MVC.Models.Validadores.Estrutura;
using MySqlX.XDevAPI;
using NSubstitute;

namespace EstacionamentoTech.TestesUnitarios.ValidadoresTests
{
    [TestFixture]
    public class TabelaValoresValidadorTests
    {
        private IContext _contexto;
        private IValidador<TabelaValores> _validador;

        private TabelaValores _vigenciaPadrao = new TabelaValores()
        {
            Id = 0,
            DataInicio = new DateTime(2025, 11, 2),
            DataFim = new DateTime(2025, 11, 1),
            ValorHoraInicial = 1,
            ValorHoraAdicional = 2
        };

        [SetUp]
        public void Setup()
        {
            _contexto = Substitute.For<IContext>();
            _validador = new TabelaValoresValidador(_contexto);
        }

        [Test]
        public void VigenciaComInicioPosterioAoFim_NaoDeveSerSalva()
        {
            //Arrange
            var vigenciaInvalida = new TabelaValores()
            {
                Id = 0,
                DataInicio = new DateTime(2025, 11, 2),
                DataFim = new DateTime(2025, 11, 1),
                ValorHoraInicial = 1,
                ValorHoraAdicional = 2
            };

            //Act
            var validacao = _validador.ValidarNoCriar(vigenciaInvalida);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }

        [Test]
        public void VigenciaComDependecia_NaoPodeSerExcluida()
        {
            //Arrange
            _contexto.TemDependencias<TabelaValores>(Arg.Any<TabelaValores>(),
                                                    Arg.Any<TabelaHistoricoEstacionamentos>(),
                                                    Arg.Any<string>()).Returns(true);

            //Act
            var validacao = _validador.ValidarNoDelete(_vigenciaPadrao);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }

        [Test]
        public void VigenciaComDependecia_NaoPodeSerEditada()
        {
            //Arrange
            _contexto.TemDependencias<TabelaValores>(Arg.Any<TabelaValores>(),
                                                    Arg.Any<TabelaHistoricoEstacionamentos>(),
                                                    Arg.Any<string>()).Returns(true);

            //Act
            var validacao = _validador.ValidarNoEditar(_vigenciaPadrao);

            //Assert
            Assert.That(validacao, Is.Not.Null);
        }
    }
}
