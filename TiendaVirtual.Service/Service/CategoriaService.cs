using System;
using System.Collections.Generic;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service
{
    public class CategoriaService : ICategoriaService
    {
        private IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Categoria model)
        {
            bool rpta = false;
            using (var context = _unitOfWork.Create())
            {
                // Header
                if(context.Repositories.CategoriaRepository.Create(model))
                {
                    // Confirm changes
                    context.SaveChanges();
                    rpta = true;
                }
                //return rpta;
            }
        }

        public void Delete(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.CategoriaRepository.Remove(id);

                // Confirm changes
                context.SaveChanges();
            }
        }

        public Categoria Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.CategoriaRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.CategoriaRepository.GetAll();
                return records;
            }
        }

        public void Update(Categoria model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.CategoriaRepository.Update(model);

                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
