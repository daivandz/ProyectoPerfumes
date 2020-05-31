using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}