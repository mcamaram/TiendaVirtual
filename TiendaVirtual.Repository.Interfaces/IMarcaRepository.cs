using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IMarcaRepository:ICreateRepository<Marca>,IReadRepository<Marca, int>,IUpdateRepository<Marca>,IRemoveRepository<int>
    {

    }
}
