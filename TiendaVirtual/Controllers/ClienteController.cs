using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Models;
using TiendaVirtual.Service.Contract;

namespace TiendaVirtual.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        // GET: ClienteController
        public ActionResult Index()
        {
            var lst = _clienteService.GetAll();
            return View(lst);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Crud(int id=0)
        {
            return View(id > 0 ? _clienteService.Get(id): new Cliente());
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(collection.Id > 0)
                    {
                        _clienteService.Update(collection);
                    }
                    else
                    {
                        _clienteService.Create(collection);
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _clienteService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
