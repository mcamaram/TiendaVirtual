using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface IMarcaService
    {
        IEnumerable<Marca> GetAll();
        Marca Get(int id);
        void Create(Marca model);
        void Update(Marca model);
        void Delete(int id);
    }
}
