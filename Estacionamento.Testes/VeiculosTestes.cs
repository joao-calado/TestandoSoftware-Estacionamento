using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Estacionamento.Testes
{
    public class VeiculosTestes
    {
        [Fact(DisplayName = "Teste n�1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n�2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n�3", Skip = "Teste ainda n�o implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Jo�o Calado";
            carro.Cor = "Vermelho";
            carro.Modelo = "Gol Quadrado";
            carro.Placa = "bzn-2486";
            carro.Tipo = TipoVeiculo.Automovel;

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo", dados);
        }

    }
}