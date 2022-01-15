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

    public class SucursalBController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalBController(ApplicationDbContext context)
        {
            _context = context;
        }


        //GET INDEX
        public IActionResult Index()
        {
            IEnumerable<Sucursal_B> listSucursalB = _context.Sucursal_B;
            return View(listSucursalB);
        }

        
        //GET CREATE
        public IActionResult Create()
        {

            return View();
        }

        
        //POST CREATE
        [HttpPost]
        public IActionResult Create(Sucursal_B prod_sucursal_B)
        {
            if (ModelState.IsValid)
            {
                _context.Sucursal_B.Add(prod_sucursal_B);
                _context.SaveChanges();

                return RedirectToAction("Index");
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
            var producB = _context.Sucursal_B.Find(id);

            if (producB == null)
            {
                return NotFound();
            }

            return View(producB);
        }
       
       //POST VENTAS
       [HttpPost]
       public IActionResult Venta(Sucursal_B producB, int venta)
       {
           if (ModelState.IsValid)
           {
                producB.cantidad = producB.cantidad - venta;
               _context.Sucursal_B.Update(producB);
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
            var producB = _context.Sucursal_B.Find(id);

            if (producB == null)
            {
                return NotFound();
            }

            return View(producB);
        }

        //POST COMPRAS
        [HttpPost]
        public IActionResult Compra(Sucursal_B producB, int compra)
        {
            if (ModelState.IsValid)
            {
                producB.cantidad = producB.cantidad + compra;
                _context.Sucursal_B.Update(producB);
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
          var producB= _context.Sucursal_B.Find(id);

          if (producB == null)
          {
              return NotFound();
          }

          return View(producB);
      }

      //POST DELETE
      [HttpPost]
      public IActionResult DeleteProducto(int? id)
      {
          var producB = _context.Sucursal_B.Find(id);
          if (producB == null)
          {
              return NotFound();
          }

          _context.Sucursal_B.Remove(producB);
          _context.SaveChanges();

          return RedirectToAction("Index");
      }
      
    }
}
