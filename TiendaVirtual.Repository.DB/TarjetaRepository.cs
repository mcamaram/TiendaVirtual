using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class TarjetaRepository : Repository, ITarjetaRepository
    {
        public TarjetaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public bool Create(Tarjeta t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_AddTargeta";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@marca", t.Marca);
                command.Parameters.AddWithValue("@numero", t.Numero);

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

        public Tarjeta Get(int id)
        {
            var command = CreateCommand("sp_GetTargetaById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Tarjeta
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Marca = reader["Marca"].ToString(),
                    Numero = reader["Activo"].ToString()
                };
            }
        }

        public IEnumerable<Tarjeta> GetAll()
        {
            var result = new List<Tarjeta>();

            var command = CreateCommand("sp_GetAllTarjetas");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Tarjeta
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Marca = reader["Marca"].ToString(),
                        Numero = reader["Numero"].ToString()
                    });
                }
            }
            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_DeleteTargeta");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Tarjeta t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_UpdateTargeta";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@marca", t.Marca);
                command.Parameters.AddWithValue("@numero", t.Numero);

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
