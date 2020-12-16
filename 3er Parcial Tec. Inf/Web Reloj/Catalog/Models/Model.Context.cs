﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Catalog.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class catalogoEntities : DbContext
    {
        public catalogoEntities()
            : base("name=catalogoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Buscar_Categoria> Buscar_Categoria { get; set; }
        public virtual DbSet<busca_usuario> busca_usuario { get; set; }
        public virtual DbSet<busca_articulos> busca_articulos { get; set; }
    
        public virtual int AgregarCarrito(string cuenta, Nullable<int> idproducto, Nullable<decimal> cantidad)
        {
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var idproductoParameter = idproducto.HasValue ?
                new ObjectParameter("idproducto", idproducto) :
                new ObjectParameter("idproducto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarCarrito", cuentaParameter, idproductoParameter, cantidadParameter);
        }
    
        public virtual int AgregarCarrito2(string cuenta, Nullable<int> idproducto, Nullable<int> idimagen, Nullable<decimal> cantidad)
        {
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var idproductoParameter = idproducto.HasValue ?
                new ObjectParameter("idproducto", idproducto) :
                new ObjectParameter("idproducto", typeof(int));
    
            var idimagenParameter = idimagen.HasValue ?
                new ObjectParameter("idimagen", idimagen) :
                new ObjectParameter("idimagen", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarCarrito2", cuentaParameter, idproductoParameter, idimagenParameter, cantidadParameter);
        }
    
        public virtual int AgregarProductos(string codigo, string nombre, string descripcion, string imagen, Nullable<decimal> precio, Nullable<int> idcategoria, string ubicacion, string nota)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var idcategoriaParameter = idcategoria.HasValue ?
                new ObjectParameter("idcategoria", idcategoria) :
                new ObjectParameter("idcategoria", typeof(int));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("ubicacion", ubicacion) :
                new ObjectParameter("ubicacion", typeof(string));
    
            var notaParameter = nota != null ?
                new ObjectParameter("nota", nota) :
                new ObjectParameter("nota", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarProductos", codigoParameter, nombreParameter, descripcionParameter, imagenParameter, precioParameter, idcategoriaParameter, ubicacionParameter, notaParameter);
        }
    
        public virtual int AgregarUsuarios(Nullable<int> tipo, string userName, string password, string nombre, string whatsApp, string telefono, string direccion)
        {
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var whatsAppParameter = whatsApp != null ?
                new ObjectParameter("WhatsApp", whatsApp) :
                new ObjectParameter("WhatsApp", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarUsuarios", tipoParameter, userNameParameter, passwordParameter, nombreParameter, whatsAppParameter, telefonoParameter, direccionParameter);
        }
    
        public virtual ObjectResult<buscaventas_Result> buscaventas(Nullable<System.DateTime> desde, Nullable<System.DateTime> hasta)
        {
            var desdeParameter = desde.HasValue ?
                new ObjectParameter("desde", desde) :
                new ObjectParameter("desde", typeof(System.DateTime));
    
            var hastaParameter = hasta.HasValue ?
                new ObjectParameter("hasta", hasta) :
                new ObjectParameter("hasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscaventas_Result>("buscaventas", desdeParameter, hastaParameter);
        }
    
        public virtual ObjectResult<ConsultarProductos_Result> ConsultarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarProductos_Result>("ConsultarProductos");
        }
    
        public virtual int inserta_compra(string cuenta, Nullable<decimal> monto)
        {
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("inserta_compra", cuentaParameter, montoParameter);
        }
    
        public virtual int inserta_detalle_compra(string cuenta, Nullable<int> id_producto, Nullable<decimal> cantidad, Nullable<decimal> precio)
        {
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var id_productoParameter = id_producto.HasValue ?
                new ObjectParameter("id_producto", id_producto) :
                new ObjectParameter("id_producto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("inserta_detalle_compra", cuentaParameter, id_productoParameter, cantidadParameter, precioParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<buscausuarios_Result> buscausuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscausuarios_Result>("buscausuarios");
        }
    }
}