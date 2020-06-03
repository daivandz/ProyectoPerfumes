using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Coment { get; set; }
        public int PerfumeId { get; set; }
        [ForeignKey("PerfumeId")]
        public Perfume Perfume { get; set; }
    }
}