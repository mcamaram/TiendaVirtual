using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class TarjetaService : ITarjetaService
    {
        private IUnitOfWork _unitOfWork;

        public TarjetaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Tarjeta model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                if (context.Repositories.TarjetaRepository.Create(model))
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
                context.Repositories.TarjetaRepository.Remove(id);

                // Confirm changes
                context.SaveChanges();
            }
        }

        public Tarjeta Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.TarjetaRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Tarjeta> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.TarjetaRepository.GetAll();
                return records;
            }
        }

        public void Update(Tarjeta model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.TarjetaRepository.Update(model);

                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
