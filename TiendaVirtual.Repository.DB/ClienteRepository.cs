using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(Cliente t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCliente";
                var command = CreateCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombres", t.Nombres);
                command.Parameters.AddWithValue("@Apellidos", t.Apellidos);
                command.Parameters.AddWithValue("@Dni", t.Dni);
                command.Parameters.AddWithValue("@Telefono", t.Telefono);
                command.Parameters.AddWithValue("@Correo", t.Correo);
                command.Parameters.AddWithValue("@Direccion", t.Direccion);
                command.Parameters.AddWithValue("@OperationType", 1);

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

        public Cliente Get(int id)
        {
            var command = CreateCommand("sp_GetClienteById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Cliente
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombres = reader["Nombres"].ToString(),
                    Apellidos = reader["Apellidos"].ToString(),
                    Dni = reader["Dni"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    Direccion = reader["Direccion"].ToString()
                };
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();

            var command = CreateCommand("sp_GetAllClientes");
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Dni = reader["Dni"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Direccion = reader["Direccion"].ToString()
                    });
                }
            }

            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_CUDCliente");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombres", "");
            command.Parameters.AddWithValue("@Apellidos", "");
            command.Parameters.AddWithValue("@Dni", "");
            command.Parameters.AddWithValue("@Telefono", "");
            command.Parameters.AddWithValue("@Correo", "");
            command.Parameters.AddWithValue("@Direccion", "");
            command.Parameters.AddWithValue("@OperationType", 3);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Cliente t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCliente";
                var command = CreateCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombres", t.Nombres);
                command.Parameters.AddWithValue("@Apellidos", t.Apellidos);
                command.Parameters.AddWithValue("@Dni", t.Dni);
                command.Parameters.AddWithValue("@Telefono", t.Telefono);
                command.Parameters.AddWithValue("@Correo", t.Correo);
                command.Parameters.AddWithValue("@Direccion", t.Direccion);
                command.Parameters.AddWithValue("@OperationType", 2);

                int valor = command.ExecuteNonQuery();
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
