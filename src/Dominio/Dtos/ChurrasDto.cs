using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Dtos
{
    public class ChurrasDto
    {
        [Required(ErrorMessage="Campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="Campo {0} é obrigatório")]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}