using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class EstadoModel
    {
        [Key]
        public int EstadoId { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
    }
}