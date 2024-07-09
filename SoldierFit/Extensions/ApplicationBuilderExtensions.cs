namespace Microsoft.AspNetCore.Builder
{
    using Microsoft.AspNetCore.Identity;
    using static SoldierFit.Utilities.WebConstants;

    /// <summary>
    /// Extension methods for configuring application services.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Ensures that the 'Administrator' role exists and the admin user is created and assigned to this role if necessary.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && !await roleManager.RoleExistsAsync(AdminRoleName))
            {
                var role = new IdentityRole(AdminRoleName);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminEmail);

                if (admin is null)
                {
                    admin = new IdentityUser { UserName = AdminEmail, Email = AdminEmail };
                    await userManager.CreateAsync(admin, AdminPassword);
                }

                await userManager.AddToRoleAsync(admin, role.Name);
            }
        }
    }
}