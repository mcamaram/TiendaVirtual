using System;
using System.Collections.Generic;
using System.Text;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual.Service.Service
{
    public class PedidoService : IPedidoService
    {
        private IUnitOfWork _unitOfWork;
        public PedidoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Pedido model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.PedidoRepository.Create(model);

                // Detail
                context.Repositories.PedidoDetalleRepository.Create(model.Detalle, model.Id);

                // Confirm changes
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.PedidoRepository.Remove(id);
                // Confirm changes
                context.SaveChanges();
            }
        }

        public Pedido Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.PedidoRepository.Get(id);

                result.cliente = context.Repositories.ClientRepository.Get(result.IdCliente);
                result.Detalle = context.Repositories.PedidoDetalleRepository.GetAllByPedidoId(result.Id);

                foreach (var item in result.Detalle)
                {
                    item.ObjProducto = context.Repositories.ProductRepository.Get(item.IdProducto);
                }

                return result;
            }
        }

        public IEnumerable<Pedido> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.PedidoRepository.GetAll();

                foreach (var record in records)
                {
                    record.cliente = context.Repositories.ClientRepository.Get(record.IdCliente);
                    record.Detalle = context.Repositories.PedidoDetalleRepository.GetAllByPedidoId(record.Id);

                    foreach (var item in record.Detalle)
                    {
                        item.ObjProducto = context.Repositories.ProductRepository.Get(item.IdProducto);
                    }
                }

                return records;
            }
        }

        public void Update(Pedido model)
        {
            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.PedidoRepository.Update(model);

                // Detail
                context.Repositories.PedidoDetalleRepository.RemoveByPedidoId(model.Id);
                context.Repositories.PedidoDetalleRepository.Create(model.Detalle, model.Id);

                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
