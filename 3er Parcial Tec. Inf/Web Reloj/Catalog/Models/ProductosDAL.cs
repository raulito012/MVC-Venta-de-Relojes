using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Web.Mvc;
namespace Catalog.Models
{
    public class ProductosDAL
    {
        IDbConnection _conn = DBCommon.conexion();

        //crear metodo agreagar productos
        public int AgregarProductos(ProductosModel pEN)
        {
           
                if (pEN.idcategoria == 0)
                    pEN.idcategoria = 10;

                if (string.IsNullOrEmpty(pEN.ubicacion))
                    pEN.ubicacion = "N";

                if (string.IsNullOrEmpty(pEN.codigo))
                    pEN.codigo = "N";

                if (string.IsNullOrEmpty(pEN.nota))
                    pEN.nota= "N";
               

                _conn.Open();
                SqlCommand _Comand = new SqlCommand("AgregarProductos", _conn as SqlConnection);
                _Comand.CommandType = CommandType.StoredProcedure;
                _Comand.Parameters.Add(new SqlParameter("@codigo", pEN.codigo));
                _Comand.Parameters.Add(new SqlParameter("@nombre", pEN.nombre));
                _Comand.Parameters.Add(new SqlParameter("@descripcion", pEN.descripcion));
                _Comand.Parameters.Add(new SqlParameter("@imagen", pEN.imagen));
                _Comand.Parameters.Add(new SqlParameter("@precio", pEN.precio));
                _Comand.Parameters.Add(new SqlParameter("@idcategoria", Convert.ToInt16(pEN.idcategoria)));
                _Comand.Parameters.Add(new SqlParameter("@ubicacion", pEN.ubicacion));
                _Comand.Parameters.Add(new SqlParameter("@nota", pEN.nota));
                int resultado = _Comand.ExecuteNonQuery();
                _conn.Close();

                return resultado;
            
        }


        //crear metodo agreagar usuarios
        public int AgregarUsuarios(RegisterViewModel pEN)
        {
            pEN.Tipo = 0;
                                
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarUsuarios", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Tipo", pEN.Tipo));
            _Comand.Parameters.Add(new SqlParameter("@UserName", pEN.UserName));
            _Comand.Parameters.Add(new SqlParameter("@Password", pEN.Password));
            _Comand.Parameters.Add(new SqlParameter("@Nombre", pEN.Nombre));
            _Comand.Parameters.Add(new SqlParameter("@WhatsApp", pEN.WhatsApp));
            _Comand.Parameters.Add(new SqlParameter("@Telefono", pEN.Telefono));
            _Comand.Parameters.Add(new SqlParameter("@Direccion", pEN.Direccion));
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }

        //Actualizar Datos
           public int ActualizarDatos(ManageUserViewModel pEN)
            {
               pEN.Password = "000000";
               pEN.Tipo = 1;
               
                _conn.Open();
                SqlCommand _Comand = new SqlCommand("AgregarUsuarios", _conn as SqlConnection);
                _Comand.CommandType = CommandType.StoredProcedure;
                _Comand.Parameters.Add(new SqlParameter("@Tipo", pEN.Tipo));
                _Comand.Parameters.Add(new SqlParameter("@UserName", pEN.Cuenta));
                _Comand.Parameters.Add(new SqlParameter("@Password", pEN.Password));
                _Comand.Parameters.Add(new SqlParameter("@Nombre", pEN.Nombre));
                _Comand.Parameters.Add(new SqlParameter("@WhatsApp", pEN.WhatsApp));
                _Comand.Parameters.Add(new SqlParameter("@Telefono", pEN.Telefono));
                _Comand.Parameters.Add(new SqlParameter("@Direccion", pEN.Direccion));
                int resultado = _Comand.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
            
        //metodo consultar productos para Listado de productos
           public List<ProductosModel> ConsultarProductos()
        {
            ProductosModel p = new ProductosModel();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select *from Productos where descripcion like '%"+p.buscar+"%'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ProductosModel> _lista = new List<ProductosModel>();
            while (_reader.Read())
            {
                ProductosModel pEN = new ProductosModel();
                pEN.id = _reader.GetInt32(0);
                pEN.nombre = _reader.GetString(1);
                pEN.descripcion = _reader.GetString(2);
                pEN.imagen = _reader.GetString(3);
                pEN.precio = _reader.GetDecimal(4);

                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }


           public List<ProductosModel> FiltraProductos(ProductosModel p)
           {
             
               _conn.Open();
               SqlCommand _Comand = new SqlCommand("select *from Productos where nombre like '%" + p.buscar + "%' order by nombre", _conn as SqlConnection);
               _Comand.CommandType = CommandType.Text;
               IDataReader _reader = _Comand.ExecuteReader();
               List<ProductosModel> _lista = new List<ProductosModel>();
               while (_reader.Read())
               {
                   ProductosModel pEN = new ProductosModel();
                   pEN.id = _reader.GetInt32(0);
                   pEN.nombre = _reader.GetString(1);
                   pEN.descripcion = _reader.GetString(2);
                   pEN.imagen = _reader.GetString(3);
                   pEN.precio = _reader.GetDecimal(4);
                   pEN.ubicacion = _reader.GetString(6);
                   pEN.nota = _reader.GetString(7);
                   _lista.Add(pEN);
               }
               _conn.Close();
               return _lista;
           }


        //Editar productos
           public List<ProductosModel> EditarProductos(ProductosModel p)
           {

               _conn.Open();
               SqlCommand _Comand = new SqlCommand("select P.*, i.* from Productos P left join imagen i on P.id = i.id_producto where p.id =" + p.id + "", _conn as SqlConnection);
               _Comand.CommandType = CommandType.Text;
               IDataReader _reader = _Comand.ExecuteReader();
               List<ProductosModel> _lista = new List<ProductosModel>();
               while (_reader.Read())
               {
                   ProductosModel pEN = new ProductosModel();
                   pEN.id = _reader.GetInt32(0);
                   pEN.nombre = _reader.GetString(1);
                   pEN.descripcion = _reader.GetString(2);
                   pEN.imagen = _reader.GetString(3);
                   pEN.precio = _reader.GetDecimal(4);
                   pEN.idcategoria =  _reader.GetInt32(5);
                   pEN.ubicacion = _reader.GetString(6);
                   pEN.nota = _reader.GetString(7);
                   
                   try
                   {
                       pEN.fotos = _reader.GetString(10);
                       pEN.id_fotos = _reader.GetInt32(8);
                   }
                   catch(Exception)
                   {

                   }
                   _lista.Add(pEN);
               }
               _conn.Close();
               return _lista;
           }



        //muestra los datos del cliente 
        public List<ManageUserViewModel> ConsultarDatosCliente()
        {
            ManageUserViewModel pEN = new ManageUserViewModel();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select *from Usuarios where Username ='" + HttpContext.Current.User.Identity.Name + "'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ManageUserViewModel> _lista = new List<ManageUserViewModel>();
            while (_reader.Read())
            {
                               
                pEN.Nombre = _reader.GetString(5);
                pEN.WhatsApp = _reader.GetString(6);
                pEN.Telefono = _reader.GetString(7);
                pEN.Direccion = _reader.GetString(8);

                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        //crear metodo Actualiza contrasena
        public int ActualizarClave(ManageUserViewModel pEN)
        {
           

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("update Usuarios set Password ='" + pEN.NewPassword + "' where Username = '" + pEN.Cuenta + "'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
           // _Comand.Parameters.Add(new SqlParameter("@PassWord", pEN.NewPassword));
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }


        //crear metodo agragar a carrito
      /*  public int AgregarCarrito(ModelCarrito pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarCarrito", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@cuenta", HttpContext.Current.User.Identity.Name));
            _Comand.Parameters.Add(new SqlParameter("@idproducto", pEN.idproducto));
            _Comand.Parameters.Add(new SqlParameter("@cantidad", pEN.cantidad));
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }*/

        //crear metodo agragar a carrito por colores
        public int AgregarCarrito(ModelCarrito pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarCarrito2", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@cuenta", HttpContext.Current.User.Identity.Name));
            _Comand.Parameters.Add(new SqlParameter("@idproducto", pEN.idproducto));
            _Comand.Parameters.Add(new SqlParameter("@idimagen", pEN.idimagen));
            _Comand.Parameters.Add(new SqlParameter("@cantidad", 1));
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }

        //metodo Mostrar Carrito
        public List<ModelCarrito> ConsultarCarrito()
        {
          
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select C.*,P.nombre,P.descripcion,P.precio,(select cast((C.cantidad * P.precio) as  decimal(16,2))) as Importe, (select cast((sum(C.cantidad * P.precio)) as  decimal(16,2)) from Productos p inner join Carrito C on P.id = C.idproducto  where C.cuenta = '" + HttpContext.Current.User.Identity.Name + "') as Total, Ca.descripcion  from Productos p inner join Carrito C on P.id = C.idproducto inner join imagen i on i.id = c.idimagen inner join Categoria ca on i.idcolor = ca.idCategoria where C.cuenta = '" + HttpContext.Current.User.Identity.Name + "'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ModelCarrito> _lista = new List<ModelCarrito>();
            while (_reader.Read())
            {
                ModelCarrito pEN = new ModelCarrito();
                pEN.idproducto = _reader.GetInt32(2);
                pEN.nombre = _reader.GetString(6);
                pEN.descripcion = _reader.GetString(7);
                pEN.cantidad = _reader.GetDecimal(4);
                pEN.precio = _reader.GetDecimal(8);
                pEN.importe = _reader.GetDecimal(9);
                pEN.total = _reader.GetDecimal(10);
                pEN.color = _reader.GetString(11);
                pEN.idimagen = _reader.GetInt32(3);
                
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        //crear metodo Quitar del carrito
        public int EliminarCarrito(ModelCarrito pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("delete from Carrito where idproducto =" + pEN.idproducto + " and cuenta ='" + HttpContext.Current.User.Identity.Name + "'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }

        //Eliminar producto
        public int EliminarProducto(ProductosModel pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("delete from Productos where id =" + pEN.id + "", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }

        //crear metodo agreagar compra
        public int AgregarCompra(ModelCarrito pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("inserta_compra", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@cuenta", HttpContext.Current.User.Identity.Name));
            _Comand.Parameters.Add(new SqlParameter("@monto", pEN.total));

             int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;

        }

        //metodo Mostrar estado de compras
        public List<ModelCompra> ConsultarEstado()
        {

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select u.nombre,c.fecha,c.hora,c.estado,row_number() OVER (ORDER BY c.id) AS posicion,c.cuenta from Usuarios u inner join compra c on u.UserName = c.cuenta", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ModelCompra> _lista = new List<ModelCompra>();
            while (_reader.Read())
            {
                ModelCompra pEN = new ModelCompra();
                pEN.cliente = _reader.GetString(0);
                pEN.fecha_solicitado = Convert.ToString(_reader.GetDateTime(1)).Substring(0,10);
                pEN.hora = _reader.GetString(2);
                pEN.estado = _reader.GetString(3);
                pEN.posicion = _reader.GetInt64(4);
                pEN.cuenta = _reader.GetString(5);
               _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }


        //metodo Mostrar despacho
        public List<ModelCompra> Consultardespacho()
        {

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select u.nombre,c.fecha,c.hora,c.estado,row_number() OVER (ORDER BY c.id) AS posicion,c.cuenta,c.id from Usuarios u inner join compra c on u.UserName = c.cuenta where c.estado = 'Pendiente'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ModelCompra> _lista = new List<ModelCompra>();
            while (_reader.Read())
            {
                ModelCompra pEN = new ModelCompra();
                pEN.cliente = _reader.GetString(0);
                pEN.fecha_solicitado = Convert.ToString(_reader.GetDateTime(1)).Substring(0, 10);
                pEN.hora = _reader.GetString(2);
                pEN.estado = _reader.GetString(3);
                pEN.posicion = _reader.GetInt64(4);
                pEN.cuenta = _reader.GetString(5);
                pEN.id = _reader.GetInt32(6);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        //crear metodo crear despacho
        public int Agregardespacho(ModelCompra pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("update compra set estado ='Despachado', fecha_despacho  = getdate() where id = " + pEN.id + "", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;

        }

        //eliminar imagenes
        public int EliminarImagenes(ProductosModel pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("delete from imagen where id =" + pEN.id_fotos + "", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;

          //  SqlCommand _Comand2 = new SqlCommand("update productos set imagen = '' where id =" + pEN.id + "", _conn as SqlConnection);
           // _Comand2.CommandType = CommandType.Text;
            
            int resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }


        //metodo consultar ver todas las fotos 
        public List<ProductosModel> ConsultarFotos(ProductosModel p)
        {
           // ProductosModel p = new ProductosModel();

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select i.id,i.id_producto,i.imagen,c.descripcion,p.nota, (select count(i.id) from imagen i inner join categoria c on i.idcolor = c.idCategoria inner join Productos p on p.id = i.id_producto where i.id_producto =" + p.idfotos + ") from imagen i inner join categoria c on i.idcolor = c.idCategoria inner join Productos p on p.id = i.id_producto where i.id_producto =" + p.idfotos + "", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ProductosModel> _lista = new List<ProductosModel>();
            while (_reader.Read())
            {
                ProductosModel pEN = new ProductosModel();
                pEN.idfotos = _reader.GetInt32(0);
                pEN.idproducto = _reader.GetInt32(1);
                pEN.imagen = _reader.GetString(2);
                pEN.color = _reader.GetString(3);
                pEN.nota = _reader.GetString(4);
                pEN.tamano = _reader.GetInt32(5);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }


        //metodo consultar historial ventas
        public List<ModelCompra> Consultarventas(ModelCompra p)
        {
            DateTime now = DateTime.Now;

            if (string.IsNullOrEmpty(p.desde))
                p.desde = now.ToString().Substring(0,10);

            if (string.IsNullOrEmpty(p.hasta))
                p.hasta = now.ToString().Substring(0, 10);

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("select *,(select sum(monto) from compra as monto where estado = 'Despachado' and fecha_despacho Between '" + p.desde.Substring(0, 10) + "' And '" + p.hasta.Substring(0, 10) + "')from compra where estado = 'Despachado' and fecha_despacho Between '" + p.desde.Substring(0, 10) + "' And '" + p.hasta.Substring(0, 10) + "'", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ModelCompra> _lista = new List<ModelCompra>();
            while (_reader.Read())
            {
                ModelCompra pEN = new ModelCompra();
                pEN.id = _reader.GetInt32(0);
                pEN.cuenta = _reader.GetString(1);
                pEN.monto = _reader.GetDecimal(2);
                pEN.fecha_solicitado = Convert.ToString(_reader.GetDateTime(3)).Substring(0, 10); 
                pEN.estado = _reader.GetString(5);
                pEN.fecha_despacho = Convert.ToString(_reader.GetDateTime(6)).Substring(0, 10);
                pEN.total = _reader.GetDecimal(7);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }


        public List<ModelCompra> graficarventas(ModelCompra p)
        {
            DateTime now = DateTime.Now;

            if (string.IsNullOrEmpty(p.desde))
                p.desde = "0";
           
          

           

            _conn.Open();
            SqlCommand _Comand = new SqlCommand("SELECT MONTH(fecha_despacho) AS Mes, SUM(monto) FROM compra where YEAR(fecha_despacho) = "+p.desde+" GROUP BY month(fecha_despacho)", _conn as SqlConnection);
            _Comand.CommandType = CommandType.Text;
            IDataReader _reader = _Comand.ExecuteReader();
            List<ModelCompra> _lista = new List<ModelCompra>();
            while (_reader.Read())
            {
                ModelCompra pEN = new ModelCompra();
                pEN.id = _reader.GetInt32(0);            
                pEN.total = _reader.GetDecimal(1);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }
    }
}