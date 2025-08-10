using Microsoft.AspNetCore.Identity;

namespace UsuarioRol.Models
{
    public class Usuarios : IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}
