using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IProductoRepository ProductRepository { get; }
        IClienteRepository ClientRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IMarcaRepository MarcaRepository { get; }
        ITarjetaRepository TarjetaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IPedidoDetalleRepository PedidoDetalleRepository { get; }
    }
}
