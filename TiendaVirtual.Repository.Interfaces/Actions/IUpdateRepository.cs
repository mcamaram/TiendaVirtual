using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Repository.Interfaces.Actions
{
    public interface IUpdateRepository<T> where T: class
    {
        bool Update(T t);
    }
}
