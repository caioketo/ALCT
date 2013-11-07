using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class TelefoneModel
    {
        [Key]
        [Column(Order = 1)]
        public int TelefoneId { get; set; }
        public string Numero { get; set; }

        [ForeignKey("Contato")]
        [Column(Order = 2)]
        public int? ContatoID { get; set; }
        public virtual ContatoModel Contato { get; set; }

    }
}