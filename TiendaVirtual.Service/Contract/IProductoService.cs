using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll();
        Producto Get(int id);
        bool Create(Producto model);
        bool Update(Producto model);
        bool Delete(int id);
    }
}
