using Inventario_ACME.Data;
using Inventario_ACME.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace Inventario_ACME.Controllers
{

    public class SucursalAController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalAController(ApplicationDbContext context)
        {
            _context = context;
        }


        //GET INDEX
        public IActionResult Index()
        {
            IEnumerable<Sucursal_A> listSucursalA = _context.Sucursal_A;
            return View(listSucursalA);
        }

        
        //GET CREATE
        public IActionResult Create()
        {

            return View();
        }

        
        //POST CREATE
        [HttpPost]
        public IActionResult Create(Sucursal_A prod_sucursal_A)
        {
            if (ModelState.IsValid)
            {
                var producA = _context.Producto.Find(prod_sucursal_A.product_id);

                if (producA == null)
                {
                    TempData["Error"] = "El Id de producto que ingresaste no existe";
                    return View();
                }
                else
                {
                    _context.Sucursal_A.Add(prod_sucursal_A);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                
            }

            return View();
        }

       

        //GET VENTAS
        public IActionResult Venta(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producA = _context.Sucursal_A.Find(id);

            if (producA == null)
            {
                return NotFound();
            }

            return View(producA);
        }
       
       //POST VENTAS
       [HttpPost]
       public IActionResult Venta(Sucursal_A producA, int venta)
       {
           if (ModelState.IsValid)
           {
                producA.cantidad = producA.cantidad - venta;
               _context.Sucursal_A.Update(producA);
               _context.SaveChanges();

               return RedirectToAction("Index");
           }
           return View();
       }

        //GET COMRPAS
        public IActionResult Compra(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //OBTIENE DATOS DEL PRODUCTO
            var producA = _context.Sucursal_A.Find(id);

            if (producA == null)
            {
                return NotFound();
            }

            return View(producA);
        }

        //POST COMPRAS
        [HttpPost]
        public IActionResult Compra(Sucursal_A producA, int compra)
        {
            if (ModelState.IsValid)
            {
                producA.cantidad = producA.cantidad + compra;
                _context.Sucursal_A.Update(producA);
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
          var producA = _context.Sucursal_A.Find(id);

          if (producA == null)
          {
              return NotFound();
          }

          return View(producA);
      }

      //POST DELETE
      [HttpPost]
      public IActionResult DeleteProducto(int? id)
      {
          var producA = _context.Sucursal_A.Find(id);
          if (producA == null)
          {
              return NotFound();
          }

          _context.Sucursal_A.Remove(producA);
          _context.SaveChanges();

          return RedirectToAction("Index");
      }
      
    }
}
