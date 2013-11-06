using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class ImovelModel
    {
        [Key]
        [Column(Order = 1)]
        public int ImovelId { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Condominio { get; set; }
        public double IPTU { get; set; }
        public double AreaUtil { get; set; }
        public int Vagas { get; set; }
        public int Dormitorios { get; set; }
        public int Suites { get; set; }
        public string Endereco { get; set; }
        public int Tipo { get; set; }

        [ForeignKey("Cidade")]
        [Column(Order = 2)]
        public int? CidadeID { get; set; }
        public virtual CidadeModel Cidade { get; set; }

        public virtual List<ParedeModel> Paredes { get; set; }

        public ImovelModel()
        {
            Paredes = new List<ParedeModel>();
        }
    }
}