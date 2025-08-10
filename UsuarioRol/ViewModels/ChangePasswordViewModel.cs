using System.ComponentModel.DataAnnotations;

namespace UsuarioRol.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage = "La contraseña no coincide.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmar contraseña obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nueva Contraseña")]
        public string ConfirmNewPassword { get; set; }
    }

}

