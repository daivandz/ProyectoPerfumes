using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}