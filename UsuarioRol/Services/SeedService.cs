using Microsoft.AspNetCore.Identity;
using UsuarioRol.Data;
using UsuarioRol.Models;

namespace UsuarioRol.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuarios>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                // Asegurando de que la base de datos esté lista
                logger.LogInformation("Asegurando que la base de datos esté creada.");
                await context.Database.EnsureCreatedAsync();

                // Agregando roles
                logger.LogInformation("Verificando roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                // Agregando usuario administrador
                logger.LogInformation("Verificando usuario administrador");
                var adminEmail = "admin@lizcode.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {

                    var adminUser = new Usuarios
                    {
                        NombreCompleto = "Liz Code",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Asignar rol de administrador al usuario administrador.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else 
                    {
                        logger.LogError("Error al crear el usuario administrador: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            { 
                logger.LogError(ex, "Error al sembrar la base de datos");
            }
        }
        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    throw new Exception($"Error al crear el rol '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
                
            }
        }

    }
}
