using System;
using System.Collections.Generic;

namespace Dominio.Dtos
{
    public class ContribuicaoDto
    {
        public Guid ChurrasId { get; set; }
        public double ValorPago { get; set; }
        public bool ComBebida { get; set; }
        public Guid ParticipanteId { get; set; }
    }
}