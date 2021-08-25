using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface ITarjetaRepository:ICreateRepository<Tarjeta>,IReadRepository<Tarjeta,int>,IUpdateRepository<Tarjeta>,IRemoveRepository<int>
    {

    }
}
