using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class PedidoDetalleRepository : Repository, IPedidoDetalleRepository
    {
        public PedidoDetalleRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(IEnumerable<PedidoDetalle> model, int pedidoId)
        {
            bool rpta = false;
            foreach (var detail in model)
            {
                var query = "sp_AddPedidoDetalle";
                var command = CreateCommand(query);

                command.Parameters.AddWithValue("@pedidoId", pedidoId);
                command.Parameters.AddWithValue("@productoId", detail.IdProducto);
                command.Parameters.AddWithValue("@cantidad", detail.Cantidad);
                command.Parameters.AddWithValue("@preciounitario", detail.PrecioUnitario);
                command.Parameters.AddWithValue("@subtotal", detail.SubTotal);

                int valor = command.ExecuteNonQuery();
                if (valor > 0)
                    rpta = true;
            }
            return rpta;
        }

        public IEnumerable<PedidoDetalle> GetAllByPedidoId(int pedidoId)
        {
            var result = new List<PedidoDetalle>();

            var command = CreateCommand("sp_GetAllPedidoDetalle");
            command.Parameters.AddWithValue("@pedidoId", pedidoId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new PedidoDetalle
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdPedido = Convert.ToInt32(reader["IdPedido"]),
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                        SubTotal = Convert.ToDecimal(reader["SubTotal"])
                    });
                }
            }
            return result;
        }

        public bool RemoveByPedidoId(int pedidoId)
        {
            bool rpta = false;
            var command = CreateCommand("sp_DeletePedidoDetalle");
            command.Parameters.AddWithValue("@pedidoId", pedidoId);

            int valor = command.ExecuteNonQuery();
            if (valor > 0)
            {
                rpta = true;
            }
            return rpta;   
        }
    }
}
