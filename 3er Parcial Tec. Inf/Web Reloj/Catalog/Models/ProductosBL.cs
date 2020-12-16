using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalog.Models
{
    
    public class ProductosBL
    {
        ProductosDAL _dal = new ProductosDAL();
        public int AgregarProductos(ProductosModel pEN)
        {
            return _dal.AgregarProductos(pEN);
            
        }

        public int AgregarCarrito(ModelCarrito pEN)
        {
            return _dal.AgregarCarrito(pEN);
        }

        public int EliminarCarrito(ModelCarrito pEN)
        {
            return _dal.EliminarCarrito(pEN);
        }

        public int AgregarUsuarios(RegisterViewModel pEN)
        {
            return _dal.AgregarUsuarios(pEN);
        }
        public int Agregardespacho(ModelCompra pEN)
        {
            return _dal.Agregardespacho(pEN);
        }
        public List<ProductosModel> ConsultarProductos()
        {
            return _dal.ConsultarProductos();
        }

        public List<ProductosModel> FiltraProductos(ProductosModel pEN)
        {
            return _dal.FiltraProductos(pEN);
        }

        public List<ProductosModel> EditarProductos(ProductosModel pEN)
        {
            return _dal.EditarProductos(pEN);
        }
        public List<ModelCarrito> ConsultarCarrito()
        {
            return _dal.ConsultarCarrito();
        }
        public int ActualizarDatos(ManageUserViewModel pEN)
        {
            return _dal.ActualizarDatos(pEN);
        }

        public List<ManageUserViewModel> ConsultarDatosCliente()
        {
            return _dal.ConsultarDatosCliente();
        }

        public int ActualizarClave(ManageUserViewModel pEN)
        {
            return _dal.ActualizarClave(pEN);
        }


        public int EliminarProducto(ProductosModel pEN)
        {
            return _dal.EliminarProducto(pEN);
        }

        public int AgregarCompra(ModelCarrito pEN)
        {
            return _dal.AgregarCompra(pEN);

        }

        public List<ModelCompra> ConsultarEstado()
        {
            return _dal.ConsultarEstado();
        }


        public List<ModelCompra> Consultardespacho()
        {
            return _dal.Consultardespacho();
        }
        public int Eliminarimagen(ProductosModel pEN)
        {
            return _dal.EliminarImagenes(pEN);
        }

        public List<ProductosModel> ConsultarFotos(ProductosModel pEN)
        {
            return _dal.ConsultarFotos(pEN);
        }

        public List<ModelCompra> Consultarventas(ModelCompra pEN)
        {
            return _dal.Consultarventas(pEN);
        }

        public List<ModelCompra> graficararventas(ModelCompra pEN)
        {
            return _dal.graficarventas(pEN);
        }
    }
}