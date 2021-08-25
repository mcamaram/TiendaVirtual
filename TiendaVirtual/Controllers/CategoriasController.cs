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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        // GET: CategoriasController
        public ActionResult Index()
        {
            var lst =  _categoriaService.GetAll();
            return View(lst);
        }

        // GET: CategoriasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriasController/Create
        public ActionResult Create(int id=0)
        {
            return View(id > 0 ? _categoriaService.Get(id) : new Categoria());
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Categoria collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(collection.Id > 0)
                    {
                        _categoriaService.Update(collection);
                    }
                    else
                    {
                        _categoriaService.Create(collection);
                    } 
                }
             // 
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriasController/Edit/5
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

        // GET: CategoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _categoriaService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CategoriasController/Delete/5
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
