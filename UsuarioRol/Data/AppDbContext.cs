using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuarioRol.Models;

namespace UsuarioRol.Data
{
    public class AppDbContext : IdentityDbContext<Usuarios>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
