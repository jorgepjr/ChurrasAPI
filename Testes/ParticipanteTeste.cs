using Dominio;
using Xunit;

namespace Testes
{
    public class ParticipanteTeste
    {
        [Fact]
        public void DevePagarUmChurras()
        {
            //Given
            var nome = "Jorge";
            var valorSugerido = 10f;
            var valorPago = 10f;
            var semBebida = false;

            var participante = new Participante(nome, valorSugerido);

            //When
            participante.PagarChurras(valorPago, semBebida);

            //Then
            Assert.Equal(valorPago, participante.ValorPago);
            Assert.Equal(valorSugerido, participante.ValorSugerido);
        }
    }
}