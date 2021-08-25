using System.Collections.Generic;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class MarcaService : IMarcaService
    {
        private IUnitOfWork _unitOfWork;

        public MarcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Marca model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                if (context.Repositories.MarcaRepository.Create(model))
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
                context.Repositories.MarcaRepository.Remove(id);

                // Confirm changes
                context.SaveChanges();
            }
        }

        public Marca Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.MarcaRepository.Get(id);
                return result;
            }
        }

        public IEnumerable<Marca> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.MarcaRepository.GetAll();
                return records;
            }
        }

        public void Update(Marca model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.MarcaRepository.Update(model);

                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
