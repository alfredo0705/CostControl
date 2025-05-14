using CostControl.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace CostControl.Identity
{
    public static class SeedData
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            // Crear el rol "Admin" si no existe
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new AppRole { Name = "Admin" };
                var roleResult = await roleManager.CreateAsync(role);

                if (!roleResult.Succeeded)
                {
                    Console.WriteLine("Error al crear el rol Admin.");
                    return;
                }
            }

            // Verificar si el usuario admin ya existe
            var existingUser = await userManager.FindByNameAsync("admin");
            if (existingUser == null)
            {
                var admin = new AppUser
                {
                    Address = "Calle 13",
                    Birthdate = DateTime.UtcNow,
                    DocumentId = new("1234567"),
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true
                };

                // Crear usuario con contraseña
                var result = await userManager.CreateAsync(admin, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Admin");
                    if (role == null)
                    {
                        Console.WriteLine("El rol Admin no se creó correctamente.");
                        return;
                    }

                    await userManager.AddToRoleAsync(admin, "Admin");
                    Console.WriteLine("Usuario administrador creado correctamente.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error al crear usuario: {error.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Usuario administrador ya existe.");
            }
        }
    }
}
