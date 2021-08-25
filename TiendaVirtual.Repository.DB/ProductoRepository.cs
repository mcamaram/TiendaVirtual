using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class ProductoRepository : Repository, IProductoRepository
    {

        public ProductoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(Producto t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDProducto";
                var command = CreateCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                command.Parameters.AddWithValue("@IdMarca", t.IdMarca);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                command.Parameters.AddWithValue("@Precio", t.Precio);
                command.Parameters.AddWithValue("@Url", t.Url);
                command.Parameters.AddWithValue("@Destacado", t.Destacado);
                command.Parameters.AddWithValue("@Activo", t.Activo);
                command.Parameters.AddWithValue("@OperationType", 1);

                int valor = Convert.ToInt32(command.ExecuteNonQuery());
                if (valor > 0)
                    rpta = true;
                  
            }
            catch(Exception ex)
            {
                return rpta;
                throw new Exception(ex.Message);
            }
            return rpta;
        }

        public Producto Get(int id)
        {
            var command = CreateCommand("sp_GetProductoById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Producto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                    IdMarca = Convert.ToInt32(reader["IdMarca"]),
                    Nombre = reader["Nombre"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    Precio = Convert.ToDecimal(reader["Precio"]),
                    Url = reader["Url"].ToString(),
                    Destacado = Convert.ToBoolean(reader["Destacado"].ToString()),
                    Activo = Convert.ToBoolean(reader["Activo"].ToString())
                };
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();

            var command = CreateCommand("sp_GetAllProductos");
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Producto
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                        IdMarca = Convert.ToInt32(reader["IdMarca"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Url = reader["Url"].ToString(),
                        Destacado = Convert.ToBoolean(reader["Destacado"].ToString()),
                        Activo = Convert.ToBoolean(reader["Activo"].ToString())
                    });
                }
            }

            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_CUDProducto");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@IdCategoria", 0);
            command.Parameters.AddWithValue("@IdMarca", 0);
            command.Parameters.AddWithValue("@Nombre", "");
            command.Parameters.AddWithValue("@Descripcion", "");
            command.Parameters.AddWithValue("@Precio", 0.00);
            command.Parameters.AddWithValue("@Url", "");
            command.Parameters.AddWithValue("@Destacado", false);
            command.Parameters.AddWithValue("@Activo", false);
            command.Parameters.AddWithValue("@OperationType", 3);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Producto t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDProducto";
                var command = CreateCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                command.Parameters.AddWithValue("@IdMarca", t.IdMarca);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                command.Parameters.AddWithValue("@Precio", t.Precio);
                command.Parameters.AddWithValue("@Url", t.Url);
                command.Parameters.AddWithValue("@Destacado", t.Destacado);
                command.Parameters.AddWithValue("@Activo", t.Activo);
                command.Parameters.AddWithValue("@OperationType", 2);

                int valor = command.ExecuteNonQuery();
                if (valor > 0)
                    rpta = true;
            }
            catch(Exception ex)
            {
                return rpta;
                throw new Exception(ex.Message);
            }
            return rpta;
        }
    }
}
