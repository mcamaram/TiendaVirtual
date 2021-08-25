using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Repository.Interfaces.Actions
{
    public interface ICreateRepository<T> where T: class
    {
        bool Create(T t);
    }
}
