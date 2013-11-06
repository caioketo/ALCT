using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class ParedeModel
    {
        [Key]
        [Column(Order = 1)]
        public int ParedeId { get; set; }

        [ForeignKey("Imovel")]
        [Column(Order = 2)]
        public int? ImovelID { get; set; }
        public virtual ImovelModel Imovel { get; set; }

        public int X { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }
}