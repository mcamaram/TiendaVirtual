using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class ProductoService : IProductoService
    {
        private IUnitOfWork _unitOfWork;
        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Create(Producto model)
        {
            bool rpta = false;
            using (var context = _unitOfWork.Create())
            {
                // Header
                if (context.Repositories.ProductRepository.Create(model))
                {
                    // Confirm changes
                    context.SaveChanges();
                    rpta = true;
                }
                return rpta;
                // Confirm changes
                //context.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool rpta = false;
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.ProductRepository.Remove(id);

                // Confirm changes
                context.SaveChanges();
                rpta = true;
            }
            return rpta;
        }

        public Producto Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.ProductRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.ProductRepository.GetAll();
                foreach(var record in records)
                {
                    record.objCategoria = context.Repositories.CategoriaRepository.Get(record.IdCategoria);
                    record.objMarca = context.Repositories.MarcaRepository.Get(record.IdMarca);
                }
                return records;
            }
        }

        public bool Update(Producto model)
        {
            bool rpta = false;
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.ProductRepository.Update(model);

                // Confirm changes
                context.SaveChanges();
                rpta = true;
            }
            return rpta;    
        }
    }
}
