using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class CategoriaRepository : Repository, ICategoriaRepository
    {
        public CategoriaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        #region Metodos Sincronos
        public bool Create(Categoria t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCategoria";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Activo", t.Activo);
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

        public Categoria Get(int id)
        {
            var command = CreateCommand("sp_GetCategoriaById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCategoria", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Categoria
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Activo = Convert.ToBoolean(reader["Activo"].ToString())
                };
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            var result = new List<Categoria>();

            var command = CreateCommand("sp_GetAllCategorias");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader =  command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Categoria
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(reader["Activo"].ToString())
                    });
                }
            }
            return  result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_CUDCategoria");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", "");
            command.Parameters.AddWithValue("@Activo", false);
            command.Parameters.AddWithValue("@OperationType", 3);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Categoria t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCategoria";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Activo", t.Activo);
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
        #endregion
        #region Metodos Asincronos
        public async Task<bool> CreateAsync(Categoria t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCategoria";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Activo", t.Activo);
                command.Parameters.AddWithValue("@OperationType", 1);

                int valor = Convert.ToInt32(await command.ExecuteNonQueryAsync());
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

        public async Task<Categoria> GetAsync(int id)
        {
            var command = CreateCommand("sp_GetCategoriaById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCategoria", id);

            using (var reader = await command.ExecuteReaderAsync())
            {
                reader.Read();

                return new Categoria
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Activo = Convert.ToBoolean(reader["Activo"].ToString())
                };
            }
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var result = new List<Categoria>();

            var command = CreateCommand("sp_GetAllCategorias");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    result.Add(new Categoria
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(reader["Activo"].ToString())
                    });
                }
            }
            return result;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_CUDCategoria");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", "");
            command.Parameters.AddWithValue("@Activo", false);
            command.Parameters.AddWithValue("@OperationType", 3);

            rpta = await command.ExecuteNonQueryAsync();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateAsync(Categoria t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_CUDCategoria";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", t.Id);
                command.Parameters.AddWithValue("@Nombre", t.Nombre);
                command.Parameters.AddWithValue("@Activo", t.Activo);
                command.Parameters.AddWithValue("@OperationType", 2);

                int valor = Convert.ToInt32(await command.ExecuteNonQueryAsync());
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
        #endregion
    }
}
