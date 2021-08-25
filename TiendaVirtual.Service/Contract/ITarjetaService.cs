using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface ITarjetaService
    {
        IEnumerable<Tarjeta> GetAll();
        Tarjeta Get(int id);
        void Create(Tarjeta model);
        void Update(Tarjeta model);
        void Delete(int id);
    }
}
