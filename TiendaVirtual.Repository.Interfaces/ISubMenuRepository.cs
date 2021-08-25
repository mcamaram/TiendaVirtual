using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface ISubMenuRepository
    {
        bool Create(IEnumerable<SubMenu> model, int menuId);
        IEnumerable<SubMenu> GetAllByMenuId(int menuId);
        bool RemoveByMenuId(int pedidoId);
    }
}
