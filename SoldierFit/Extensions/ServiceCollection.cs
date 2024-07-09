namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Services;
    using SoldierFit.Infrastructure.Common;
    using SoldierFit.Infrastructure.Data;

    public static class ServiceCollection
    {
        /// <summary>
        /// Adds application-specific services to the dependency injection container.
        /// </summary>
        /// <param name="services">The collection of services to add to.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IAthleteService, AthleteService>();

            return services;
        }

        /// <summary>
        /// Configures and adds the application's DbContext to the dependency injection container.
        /// </summary>
        /// <param name="services">The collection of services to add to.</param>
        /// <param name="configuration">The configuration containing the connection string.</param>
        /// <param name="environment">The hosting environment, used to determine if in development mode.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the 'DefaultConnection' connection string is not found in the configuration.</exception>
        public static IServiceCollection AddApplicationDbContext(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            string connectionString = configuration
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            if (environment.IsDevelopment())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }

            return services;
        }

        /// <summary>
        /// Configures and adds ASP.NET Core Identity services to the dependency injection container.
        /// </summary>
        /// <param name="services">The collection of services to add to.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
