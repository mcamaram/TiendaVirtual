using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface IMenuRepository
    {
        bool Create(IEnumerable<Menu> model, int moduloId);
        IEnumerable<Menu> GetAllByModuloId(int moduloId);
        bool RemoveByModuloId(int moduloId);
    }
}
