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
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMarcaService _marcaService;
        public ProductoController(IProductoService productoService,ICategoriaService categoriaService, IMarcaService marcaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _marcaService = marcaService;
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            var lst = _productoService.GetAll();
            return View(lst);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Crud(int id=0)
        {
            ViewBag.lstCategorias = _categoriaService.GetAll();
            ViewBag.lstMarcas = _marcaService.GetAll();
            return View(id > 0 ? _productoService.Get(id): new Producto());
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(collection.Id > 0)
                    {
                        _productoService.Update(collection);
                    }
                    else
                    {
                        _productoService.Create(collection);
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _productoService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductoController/Delete/5
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
