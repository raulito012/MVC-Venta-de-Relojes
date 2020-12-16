using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        
    }

    public class ManageUserViewModel
    {
        public string Nombre { get; set; }
        public string WhatsApp { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cuenta { get; set; }
        public int Tipo { get; set; }
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
          //Registro de usuarios
       
        public string descripcion { get; set; }
        [Required]
       
        [Display(Name = "Cuenta de usuario")]

                
        public string UserName { get; set; }
        [Required]    
  
        public string Nombre { get; set; }
        
        public string WhatsApp { get; set; }
        [Required]
       
        public string Telefono { get; set; }
        [Required]
       
        public string Direccion { get; set; }

        public int Tipo { get; set; }
        public string Cuenta { get; set; }
        

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

                
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }


    public class ProductosModel
    {
       
        
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string imagen { get; set; }
        [Required]
        public decimal precio { get; set; }
        public int idcategoria { get; set; }
        public string ubicacion { get; set; }
        public int id { get; set; }
        public string buscar { get; set; }
        public string codigo { get; set; }
        public string fotos { get; set; }
        public int id_fotos { get; set; }
        public int idfotos { get; set; }
        public int idproducto { get; set; }
        public string color { get; set; }
        public string nota { get; set; }
        public int tamano { get; set; }
    }

    public class ModelCarrito
    {

        public int idproducto { get; set; }
        public decimal cantidad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string fecha { get; set; }
        public decimal importe { get; set; }
        public decimal total { get; set; }
        public int idimagen { get; set; }
        public string color { get; set; }
    }

    public class ModelCompra
    {

        public string cliente { get; set; }
        public string fecha_solicitado { get; set; }
        public string fecha_despacho { get; set; }
        public string hora { get; set; }
        public string estado{ get; set; }
        public decimal monto { get; set; }
        public decimal total { get; set; }
        public int id { get; set; }
        public long posicion { get; set; }
        public string cuenta { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
     

    }

}
