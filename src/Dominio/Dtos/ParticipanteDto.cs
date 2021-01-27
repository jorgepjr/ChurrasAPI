using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Dtos
{
    public class ParticipanteDto
    {
        [Required(ErrorMessage="Campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get;  set; }
        
        [Required(ErrorMessage="Campo {0} é obrigatório")]
        [DisplayName("Valor sugerido")]
        public double ValorSugerido { get;  set; }
        public double ValorPago { get; set; }
         public bool ComBebida { get; set; }
        public Guid ChurrasId { get;  set; }

    }
}