using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Repository.DB;
using TiendaVirtual.Repository.Interfaces;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.UnitOfWork.DB
{
    public class UnitOfWorkDBRepository : IUnitOfWorkRepository
    {
        public IProductoRepository ProductRepository  { get; }

        public IClienteRepository ClientRepository  { get; }

        public ICategoriaRepository CategoriaRepository { get; }

        public IMarcaRepository MarcaRepository { get; }

        public ITarjetaRepository TarjetaRepository { get; }

        public IUsuarioRepository UsuarioRepository { get; }

        public IPedidoRepository PedidoRepository { get; }

        public IPedidoDetalleRepository PedidoDetalleRepository { get; }

        public UnitOfWorkDBRepository(SqlConnection context, SqlTransaction transaction)
        {
            ProductRepository = new ProductoRepository(context, transaction);
            ClientRepository = new ClienteRepository(context, transaction);
            CategoriaRepository = new CategoriaRepository(context, transaction);
            MarcaRepository = new MarcaRepository(context, transaction);
            TarjetaRepository = new TarjetaRepository(context, transaction);
            UsuarioRepository = new UsuarioRepository(context, transaction);
            PedidoRepository = new PedidoRepository(context, transaction);
            PedidoDetalleRepository = new PedidoDetalleRepository(context, transaction);
        }
    }
}
