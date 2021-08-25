using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario Get(int id);
        void Create(Usuario model);
        void Update(Usuario model);
        void Delete(int id);
    }
}
