using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Marca
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}