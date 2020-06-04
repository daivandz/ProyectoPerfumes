using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Comment
    {
        public int id { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        [Display(Name = "Comentario")]
        [MaxLength(500)]
        public string Coment { get; set; }
        public int PerfumeId { get; set; }
        [ForeignKey("PerfumeId")]
        public Perfume Perfume { get; set; }
    }
}