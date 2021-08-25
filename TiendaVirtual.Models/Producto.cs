using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public Categoria objCategoria { get; set; }
        public int IdMarca { get; set; }
        public Marca objMarca { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Url { get; set; }
        public bool Destacado { get; set; }
        public bool Activo { get; set; }
    }
}
