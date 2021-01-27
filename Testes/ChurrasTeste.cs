using System;
using Dominio;
using Moq;
using Xunit;

namespace Testes
{
    public class ChurrasTeste
    {
        private readonly string descricao = "Aniversario";
        private readonly DateTime data = DateTime.Now.Date;
        private readonly string nome = "Jorge";
        private readonly double valorSugerido = 10f;
        private readonly Churras churras;
        private readonly Participante participante;


        public ChurrasTeste()
        {
            this.churras = new Churras(descricao, data);
            this.participante = new Participante(nome, valorSugerido);
        }

        [Fact]
        public void DeveAdicionarUmParticipante()
        {

            churras.Adicionar(participante);

            Assert.Single(churras.Participantes);
        }

         [Fact]
        public void DeveRemoverUmParticipante()
        {
            var participante = new Mock<Participante>().Object;

            churras.Adicionar(participante);

            churras.Remover(participante);

            Assert.Empty(churras.Participantes);
        }

        [Fact]
        public void DeveRetornarVerdadeiroAoTentarCriarChurrasComDataRetroativa()
        {
            //Given
            var descricao = "Aniversario";
            var dataRetroativa = DateTime.Now.Date.AddDays(-4);

            //When
            var churras = new Churras(descricao, dataRetroativa);

            //Then
            Assert.True(churras.DataRetroativa());
        }
    }
}
