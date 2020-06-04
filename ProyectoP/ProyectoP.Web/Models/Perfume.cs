using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Perfume
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Género")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}