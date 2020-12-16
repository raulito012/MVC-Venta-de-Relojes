using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Catalog.Models;
using System.Data.SqlClient;
using System.Data;
using Rotativa;

namespace Catalog.Controllers
{
    public class ReybinController : Controller
    {
        //
        // GET: /Reybin/

        ProductosBL _bl = new ProductosBL();
        [HttpPost]
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult ListaProductos()
        {
            ViewBag.ListaProductos = _bl.ConsultarProductos().ToList();
          
            return View();
        }

        public ActionResult ListaCarrito()
        {
           
            return View();
        }
        public ActionResult Carrito()
        {
            ViewBag.ListaCarrito = _bl.ConsultarCarrito().ToList();
            return View();
        }

        catalogoEntities db = new catalogoEntities();
        //agrega productos

        public ActionResult AgregarProductos()
        {
            List<Buscar_Categoria> ListaCategoria = db.Buscar_Categoria.ToList();
            ViewBag.ListaCategoria = new SelectList(ListaCategoria, "idCategoria", "descripcion");
            ViewBag.ListaProductos = _bl.ConsultarProductos().ToList();
           
            return View();
           
        }

        public ActionResult AgregarProductos2(ProductosModel pEN)
        {
            ViewBag.EditarProductos = _bl.EditarProductos(pEN).ToList();
            _bl.AgregarProductos(pEN);
            return RedirectToAction("AgregarProductos", "Reybin");
             
        }

        public ActionResult EliminarProducto(ProductosModel pEN)
        {
             ViewBag.ListaProductosFiltrado = _bl.FiltraProductos(pEN).ToList();  
            _bl.EliminarProducto(pEN);
            return RedirectToAction("FiltraProductos", "Reybin");

        }
        public ActionResult FiltraProductos(ProductosModel pEN)
        {
            ViewBag.ListaProductosFiltrado = _bl.FiltraProductos(pEN).ToList();            
            return View();
        }

        public ActionResult EditarProductos(ProductosModel pEN)
        {
            List<Buscar_Categoria> ListaCategoria = db.Buscar_Categoria.ToList();
            ViewBag.ListaCategoria = new SelectList(ListaCategoria, "idCategoria", "descripcion");
            ViewBag.EditarProductos = _bl.EditarProductos(pEN).ToList();
           // _bl.AgregarProductos (pEN);
           // return RedirectToAction("AgregarProductos", "Reybin");
            return View();

        }

      

        [HttpPost]

      

        public ActionResult AgregarCarrito(ModelCarrito pEN)
        {
            _bl.AgregarCarrito(pEN);
            return RedirectToAction("ListaProductos", "Reybin");

        }

        public ActionResult Agregardespacho(ModelCompra pEN)
        {
            _bl.Agregardespacho(pEN);
            return RedirectToAction("Consultardespacho", "Reybin");

        }

        public ActionResult EliminarCarrito(ModelCarrito pEN)
        {
            _bl.EliminarCarrito(pEN);
            return RedirectToAction("Carrito", "Reybin");

        }

        public ActionResult Inicio()
        {

            return View();
        }

        public ActionResult AgregarCompra(ModelCarrito pEN)
        {
            _bl.AgregarCompra(pEN);
            return RedirectToAction("ListaProductos", "Reybin");

        }

        public ActionResult ConsultarEstado()
        {
            ViewBag.ListaEstado = _bl.ConsultarEstado().ToList();
            return View();
        }

        public ActionResult Consultardespacho()
        {
            ViewBag.ListaEstado = _bl.Consultardespacho().ToList();
            return View();
        }
        public ActionResult Eliminarimagen(ProductosModel pEN)
        {
            _bl.Eliminarimagen(pEN);
            return RedirectToAction("AgregarProductos", "Reybin");

        }

        public ActionResult ConsultarFotos(ProductosModel pEN)
        {
            ViewBag.ListaProductos = _bl.ConsultarFotos(pEN).ToList();
            return View();         
        }

        public ActionResult Consultarventas(ModelCompra pEN)
        {
            ViewBag.ListaProductos = _bl.Consultarventas(pEN).ToList();
            return View();
           
        }

        public ActionResult printpdf(ModelCompra pEN)
        {
            ViewBag.ListaProductos = _bl.Consultarventas(pEN).ToList();
            return new Rotativa.ViewAsPdf("Consultarventas");
        }

        public ActionResult graficaventas(ModelCompra pEN)
        {
            ViewBag.ListaProductos = _bl.graficararventas(pEN).ToList();
            return View();

        }
     
    }


}