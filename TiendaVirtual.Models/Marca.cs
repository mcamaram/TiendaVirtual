using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
