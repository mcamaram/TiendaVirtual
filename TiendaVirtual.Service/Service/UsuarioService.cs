using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Usuario model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                if (context.Repositories.UsuarioRepository.Create(model))
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
                context.Repositories.UsuarioRepository.Remove(id);

                // Confirm changes
                context.SaveChanges();
            }
        }

        public Usuario Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.UsuarioRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.UsuarioRepository.GetAll();
                return records;
            }
        }

        public void Update(Usuario model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.UsuarioRepository.Update(model);

                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
