using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class MarcaRepository : Repository, IMarcaRepository
    {
        public MarcaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(Marca t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDMarca";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdMarca", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
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

        public Marca Get(int id)
        {
            var command = CreateCommand("sp_GetMarcaById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdMarca", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Marca
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString()
                };
            }
        }

        public IEnumerable<Marca> GetAll()
        {
            var result = new List<Marca>();

            var command = CreateCommand("sp_GetAllMarcas");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Marca
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_CUDMarca");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdMarca", id);
            command.Parameters.AddWithValue("@Nombre", "");
            command.Parameters.AddWithValue("@OperationType", 3);
            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Marca t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDMarca";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdMarca", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@OperationType", 2);

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
