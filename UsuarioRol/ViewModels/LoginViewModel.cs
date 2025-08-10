using System.ComponentModel.DataAnnotations;

namespace UsuarioRol.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
