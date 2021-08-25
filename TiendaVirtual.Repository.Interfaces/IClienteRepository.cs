using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IClienteRepository: ICreateRepository<Cliente>,IReadRepository<Cliente, int>,IUpdateRepository<Cliente>,IRemoveRepository<int>
    {

    }
}
