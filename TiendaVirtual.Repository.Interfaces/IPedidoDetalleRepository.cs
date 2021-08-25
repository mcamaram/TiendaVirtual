using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IPedidoDetalleRepository
    {
        bool Create(IEnumerable<PedidoDetalle> model, int pedidoId);
        IEnumerable<PedidoDetalle> GetAllByPedidoId(int pedidoId);
        bool RemoveByPedidoId(int pedidoId);
    }
}
