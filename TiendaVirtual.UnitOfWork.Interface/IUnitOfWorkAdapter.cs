using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.UnitOfWork.Interface
{
    public interface IUnitOfWorkAdapter: IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
