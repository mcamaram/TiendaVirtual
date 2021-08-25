using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Repository.Interfaces;

namespace TiendaVirtual.Repository.DB
{
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        public UsuarioRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public bool Create(Usuario t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_AddUsuario";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombres", t.Nombres);
                command.Parameters.AddWithValue("@apellidos", t.Apellidos);
                command.Parameters.AddWithValue("@dni", t.Dni);
                command.Parameters.AddWithValue("@correo", t.Correo);
                command.Parameters.AddWithValue("@contrasena", t.Contrasena);
                command.Parameters.AddWithValue("@activo", t.Activo);

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

        public Usuario Get(int id)
        {
            var command = CreateCommand("sp_GetUsuarioById");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Usuario
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombres = reader["Nombres"].ToString(),
                    Apellidos = reader["Apellidos"].ToString(),
                    Dni = reader["Dni"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    Contrasena = reader["Contrasena"].ToString(),
                    Activo = Convert.ToBoolean(reader["Activo"].ToString())
                };
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            var result = new List<Usuario>();

            var command = CreateCommand("sp_GetAllUsers");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Dni = reader["Dni"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Contrasena = reader["Contrasena"].ToString(),
                        Activo = Convert.ToBoolean(reader["Activo"].ToString())
                    });
                }
            }
            return result;
        }

        public bool Remove(int id)
        {
            int rpta = 0;
            var command = CreateCommand("sp_DeleteUsuario");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            rpta = command.ExecuteNonQuery();
            if (rpta > 0)
                return true;
            else
                return false;
        }

        public bool Update(Usuario t)
        {
            bool rpta = false;
            try
            {
                var query = "sp_UpdateUsuario";
                var command = CreateCommand(query);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@nombres", t.Nombres);
                command.Parameters.AddWithValue("@apellidos", t.Apellidos);
                command.Parameters.AddWithValue("@dni", t.Dni);
                command.Parameters.AddWithValue("@correo", t.Correo);
                command.Parameters.AddWithValue("@contrasena", t.Contrasena);
                command.Parameters.AddWithValue("@activo", t.Activo);

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
