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
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        // GET: MarcaController
        public ActionResult Index()
        {
            var lst = _marcaService.GetAll();
            return View(lst);
        }

        // GET: MarcaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarcaController/Create
        public ActionResult Crud(int id=0)
        {
            return View(id > 0 ? _marcaService.Get(id): new Marca());
        }

        // POST: MarcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(collection.Id > 0)
                    {
                        _marcaService.Update(collection);
                    }
                    else
                    {
                        _marcaService.Create(collection);
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MarcaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcaController/Edit/5
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

        // GET: MarcaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _marcaService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: MarcaController/Delete/5
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
