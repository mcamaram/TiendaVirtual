using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.UnitOfWork.DB
{
    public class UnitOfWorkDBAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _context;
        private SqlTransaction _transaction;
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkDBAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();
            _transaction = _context.BeginTransaction();

            Repositories = new UnitOfWorkDBRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
