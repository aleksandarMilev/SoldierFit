namespace SoldierFit.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the application's database context, extending IdentityDbContext for ASP.NET Identity.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContextOptions to be used for configuring the context.</param>
        /// <exception cref="InvalidOperationException">Thrown when the 'DefaultConnection' connection string is not found in the configuration.</exception>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
