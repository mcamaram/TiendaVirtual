using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Response<T>
    {
        public bool estado { get; set; }
        public string msj { get; set; }
        public T objeto { get; set; }
    }
}
