using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Churras
    {
        protected Churras(){}
        public Churras(string descricao, DateTime data, string observacao)
        {
            Descricao = descricao;
            Data = data;
            Observacao = observacao;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }
        public string Observacao { get; private set; }
        public ICollection<Participante> Participantes { get; private set; } = new List<Participante>();

        public void Adicionar(Participante participante) => Participantes.Add(participante);
        public void Remover(Participante participante) => Participantes.Remove(participante);
    }
}
