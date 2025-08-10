using System.ComponentModel.DataAnnotations;

namespace UsuarioRol.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
