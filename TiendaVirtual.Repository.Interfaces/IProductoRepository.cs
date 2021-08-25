using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IProductoRepository: ICreateRepository<Producto>,IReadRepository<Producto,int>,IUpdateRepository<Producto>,IRemoveRepository<int>
    {

    }
}
