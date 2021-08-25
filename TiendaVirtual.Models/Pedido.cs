using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Detalle = new List<PedidoDetalle>();
        }
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente cliente { get; set; }
        public int IdTarjeta { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<PedidoDetalle> Detalle { get; set; }
    }
}
