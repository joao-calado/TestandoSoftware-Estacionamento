using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Estacionamento.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Veiculo _veiculo;
        private Operador _operador;
        private ITestOutputHelper _saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper SaidaConsoleTeste)
        {
            this._veiculo = new Veiculo();
            this._operador = new Operador();
            this._saidaConsoleTeste = SaidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor invocado");

            _operador.Nome = "Pedro Fagundes";
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            estacionamento.OperadorPatio = _operador;
            veiculo.Proprietario = "João Calado";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Gol Quadrado";
            veiculo.Placa = "bzn-2486";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        [InlineData("José Silva", "POL-9242", "cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            estacionamento.OperadorPatio = _operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            
            //Act
            double faturamento = estacionamento.TotalFaturado();
            
            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioPorIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            estacionamento.OperadorPatio = _operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            Veiculo consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            estacionamento.OperadorPatio = _operador;
            veiculo.Proprietario = "João Calado";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Gol Quadrado";
            veiculo.Placa = "bzn-2486";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "João Calado";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Gol Quadrado";
            veiculoAlterado.Placa = "bzn-2486";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Limpando Setup");
        }
    }
}
