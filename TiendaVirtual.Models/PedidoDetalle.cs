using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public Pedido ObjPedido { get; set; }
        public int IdProducto { get; set; }
        public Producto ObjProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
