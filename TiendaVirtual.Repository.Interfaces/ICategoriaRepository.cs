using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces.Actions;

namespace TiendaVirtual.Repository.Interfaces
{
    public interface ICategoriaRepository: ICreateRepository<Categoria>,IUpdateRepository<Categoria>,IReadRepository<Categoria,int>,IRemoveRepository<int>
    {

    }
}
