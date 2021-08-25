using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class PedidoRepository : Repository, IPedidoRepository
    {
        public PedidoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(Pedido t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_AddPedido";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@clienteId", t.IdCliente);
                command.Parameters.AddWithValue("@tarjetaId", t.IdTarjeta);
                command.Parameters.AddWithValue("@fechahora", t.FechaHora);
                command.Parameters.AddWithValue("@estado", t.Estado);
                command.Parameters.AddWithValue("@total", t.Total);

                int valor = Convert.ToInt32(command.ExecuteNonQuery());
                if (valor > 0)
                    rpta = true;

            }
            catch (Exception ex)
            {
                return rpta;
                throw new Exception(ex.Message);
            }
            return rpta;
        }

        public Pedido Get(int id)
        {
            var command = CreateCommand("sp_GetPedidoById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Pedido
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdCliente = Convert.ToInt32(reader["IdCliente"].ToString()),
                    IdTarjeta = Convert.ToInt32(reader["IdTarjeta"].ToString()),
                    FechaHora = Convert.ToDateTime(reader["FechaHora"].ToString()),
                    Estado = reader["Estado"].ToString(),
                    Total = Convert.ToDecimal(reader["Total"].ToString())
                };
            }
        }

        public IEnumerable<Pedido> GetAll()
        {
            var result = new List<Pedido>();

            var command = CreateCommand("sp_GetAllPedidos");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Pedido
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"].ToString()),
                        IdTarjeta = Convert.ToInt32(reader["IdTarjeta"].ToString()),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"].ToString()),
                        Estado = reader["Estado"].ToString(),
                        Total = Convert.ToDecimal(reader["Total"].ToString())
                    });
                }
            }
            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_DeletePedido");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Pedido t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_UpdatePedido";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@clienteId", t.IdCliente);
                command.Parameters.AddWithValue("@tarjetaId", t.IdTarjeta);
                command.Parameters.AddWithValue("@fechahora", t.FechaHora);
                command.Parameters.AddWithValue("@estado", t.Estado);
                command.Parameters.AddWithValue("@total", t.Total);

                int valor = Convert.ToInt32(command.ExecuteNonQuery());
                if (valor > 0)
                    rpta = true;

            }
            catch (Exception ex)
            {
                return rpta;
                throw new Exception(ex.Message);
            }
            return rpta;
        }
    }
}
