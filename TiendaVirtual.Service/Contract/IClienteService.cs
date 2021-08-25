using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;

namespace TiendaVirtual.Service.Contract
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        void Create(Cliente model);
        void Update(Cliente model);
        void Delete(int id);
    }
}
