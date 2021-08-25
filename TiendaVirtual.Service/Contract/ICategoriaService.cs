using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Categoria Get(int id);
        void Create(Categoria model);
        void Update(Categoria model);
        void Delete(int id);
    }
}
