using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
