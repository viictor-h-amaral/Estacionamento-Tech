using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoTech.Data;
using EstacionamentoTech.Models;
using EstacionamentoTech.MVC.Models;
using NSubstitute;

namespace EstacionamentoTech.TestesUnitarios.EstacionamentoTests
{
    [TestFixture]
    public class CalculoEstacionamentosTests
    {
        private HistoricoEstacionamentosExtensor _extensor;
        private IContext _contexto;

        [SetUp]
        public void Setup()
        {
            _contexto = Substitute.For<IContext>();
        }

        private static IEnumerable<object[]> EstacionamentosComAte30Minutos()
        {
            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 10, 0, 0),
                    Saida = new DateTime(2025, 11, 03, 10, 29, 0)
                }
            };

            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 10, 0, 0),
                    Saida = new DateTime(2025, 11, 03, 10, 5, 0)
                }
            };
        }

        private static IEnumerable<object[]> EstacionamentosComAte10MinutosAposUltimaHora()
        {
            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 10, 0, 0),
                    Saida = new DateTime(2025, 11, 03, 10, 40, 0)
                },
                1m
            };

            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 10, 0, 0),
                    Saida = new DateTime(2025, 11, 03, 12, 2, 0)
                },
                2m
            };
        }

        private static IEnumerable<object[]> EstacionamentosComMaisDe10MinutosAposUltimaHora()
        {
            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 10, 0, 0),
                    Saida = new DateTime(2025, 11, 03, 13, 35, 0)
                },
                4m
            };

            yield return new object[]
            {
                new HistoricoEstacionamentos
                {
                    Id = 0,
                    Entrada = new DateTime(2025, 11, 03, 23, 0, 0),
                    Saida = new DateTime(2025, 11, 04, 01, 45, 0)
                },
                3m
            };
        }

        [Test]
        [TestCaseSource(nameof(EstacionamentosComAte30Minutos))]
        public void EstacionamentoComAte30Minutos_DeveCobrarMeiaHora(HistoricoEstacionamentos estacionamento)
        {
            _extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            _extensor.CalcularHorasCobradas();

            Assert.That(estacionamento.HorasCobradas, Is.Not.Null);
            Assert.That(estacionamento.HorasCobradas, Is.EqualTo(0.5m));
        }

        [Test]
        [TestCaseSource(nameof(EstacionamentosComAte10MinutosAposUltimaHora))]
        public void EstacionamentoComAte10MinutosAposUltimaHora_DeveCobrarSomenteAteHoraInteira(HistoricoEstacionamentos estacionamento, decimal valorEsperado)
        {
            _extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            _extensor.CalcularHorasCobradas();

            Assert.That(estacionamento.HorasCobradas, Is.Not.Null);
            Assert.That(estacionamento.HorasCobradas, Is.EqualTo(valorEsperado));
        }

        [Test]
        [TestCaseSource(nameof(EstacionamentosComMaisDe10MinutosAposUltimaHora))]
        public void EstacionamentoComMaisDe10MinutosAposUltimaHora_DeveCobrarHoraCheia(HistoricoEstacionamentos estacionamento, decimal valorEsperado)
        {
            _extensor = new HistoricoEstacionamentosExtensor(_contexto, estacionamento);
            _extensor.CalcularHorasCobradas();

            Assert.That(estacionamento.HorasCobradas, Is.Not.Null);
            Assert.That(estacionamento.HorasCobradas, Is.EqualTo(valorEsperado));
        }
    }
}
