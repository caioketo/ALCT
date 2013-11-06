using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class ImagemModel
    {
        [Key]
        public int ImagemId { get; set; }
        public string Caminho { get; set; }
    }
}