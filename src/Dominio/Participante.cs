using System;

namespace Dominio
{
    public class Participante
    {
        protected Participante(){}
        public Participante(string nome, double valorSugerido)
        {
            Nome = nome;
            ValorSugerido = valorSugerido;
        }

        public Participante(double valorPago, bool comBebida)
        {
            ValorPago = valorPago;
            ComBebida = comBebida;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public double ValorSugerido { get; private set; }
        public double ValorPago { get; private set; }
        public bool ComBebida { get; private set; }
        public Guid ChurrasId { get; private set; }
        public Churras Churras { get; private set; }

        public void PagarChurras(double valorPago, bool comBebida)
        {
            this.ValorPago = valorPago;
            this.ComBebida = comBebida;
        }
    }
}