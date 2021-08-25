using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface IPedidoService
    {
        IEnumerable<Pedido> GetAll();
        Pedido Get(int id);
        void Create(Pedido model);
        void Update(Pedido model);
        void Delete(int id);
    }
}
