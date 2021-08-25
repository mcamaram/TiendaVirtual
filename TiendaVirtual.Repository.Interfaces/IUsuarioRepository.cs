using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IUsuarioRepository: ICreateRepository<Usuario>, IReadRepository<Usuario, int>, IUpdateRepository<Usuario>, IRemoveRepository<int>
    {

    }
}
