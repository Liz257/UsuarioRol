using System.ComponentModel.DataAnnotations;

namespace UsuarioRol.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nombre obligatorio")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria.")]
        [StringLength(40, MinimumLength  = 8, ErrorMessage = "La {0} debe tener al menos {2} y máximo {1} caracteres.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "La contraseña no coincide.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar contraseña obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
