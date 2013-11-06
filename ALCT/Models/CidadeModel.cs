using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class CidadeModel
    {
        [Key]
        [Column(Order = 1)]
        public int CidadeId { get; set; }

        [ForeignKey("Estado")]
        [Column(Order = 2)]
        public int? EstadoID { get; set; }
        public virtual EstadoModel Estado { get; set; }
        public string Descricao { get; set; }
    }
}