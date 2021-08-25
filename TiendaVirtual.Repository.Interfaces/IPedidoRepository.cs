using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IPedidoRepository: ICreateRepository<Pedido>, IReadRepository<Pedido, int>,IUpdateRepository<Pedido>, IRemoveRepository<int>
    {

    }
}
