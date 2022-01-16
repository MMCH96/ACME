using Inventario_ACME.Data;
using Inventario_ACME.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Inventario_ACME.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET INDEX
        public IActionResult Index()
        {
            IEnumerable<Producto> listProductos = _context.Producto;
            return View(listProductos);
        }



        //GET CREATE
        public IActionResult Create()
        {
           return View();
        }

        //POST CREATE
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        //GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //POST EDIT
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Update(producto);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //POST DELETE
        [HttpPost]
        public IActionResult DeleteProducto(int? id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET INFO SUCURSAL A
        public IActionResult InfoA(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            TempData["Id"] = " "+producto.id;
            TempData["Nombre"] = " "+producto.nombre;
            TempData["CodigoBarras"] = " "+producto.codigo_barras;
            TempData["Precio"] = " "+producto.precio;
            return RedirectToAction("Index","SucursalA");
        }

        //GET INFO SUCURSAL B
        public IActionResult InfoB(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            TempData["Id"] = " " + producto.id;
            TempData["Nombre"] = " " + producto.nombre;
            TempData["CodigoBarras"] = " " + producto.codigo_barras;
            TempData["Precio"] = " " + producto.precio;
            return RedirectToAction("Index", "SucursalB");
        }
    }
}
