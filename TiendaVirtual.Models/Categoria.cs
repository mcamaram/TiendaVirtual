using System;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
