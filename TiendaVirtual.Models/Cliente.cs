using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
