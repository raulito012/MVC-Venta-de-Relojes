using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog.Models
{
        public class ProductosEN
        {
            //productos
            public int id { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string imagen { get; set; }
            public decimal precio { get; set; }


           
          
            public string cantidad { get; set; }

            //Registro de usuarios
            public string UserName { get; set; }
            public string Password { get; set; }
            public string buscar { get; set; }
              
        
       
    }
}