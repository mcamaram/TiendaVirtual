using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class ClienteService : IClienteService
    {
        private IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Cliente model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                if (context.Repositories.ClientRepository.Create(model))
                {
                    // Confirm changes
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                if(context.Repositories.ClientRepository.Remove(id))
                {
                    // Confirm changes
                    context.SaveChanges();
                }
            }
        }

        public Cliente Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ClientRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.ClientRepository.GetAll();
                return records;
            }
        }

        public void Update(Cliente model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                if(context.Repositories.ClientRepository.Update(model))
                {
                    // Confirm changes
                    context.SaveChanges();
                }   
            }
        }
    }
}
