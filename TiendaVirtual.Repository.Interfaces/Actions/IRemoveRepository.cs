using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Repository.Interfaces.Actions
{
    public interface IRemoveRepository<T>
    {
        bool Remove(T id);
    }
}
