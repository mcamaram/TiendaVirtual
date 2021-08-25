using Microsoft.Extensions.Configuration;
using System;
using TiendaVirtual.Common;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.UnitOfWork.DB
{
    public class UnitOfWorkDB : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration == null ? Parameters.ConnectionString : _configuration.GetConnectionString("Conexion");
            return new UnitOfWorkDBAdapter(connectionString);
        }
    }
}
