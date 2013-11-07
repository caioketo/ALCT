using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class ContatoModel
    {
        [Key]
        [Column(Order = 1)]
        public int ContatoId { get; set; }
        public string Nome { get; set; }

        public virtual List<TelefoneModel> Telefones { get; set; }

        public ContatoModel()
        {
            Telefones = new List<TelefoneModel>();
        }
    }
}