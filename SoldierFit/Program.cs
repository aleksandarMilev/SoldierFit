namespace SoldierFit
{
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Profiles;

    public class Program 
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationServices();
            builder.Services.AddApplicationDbContext(builder.Configuration, builder.Environment);
            builder.Services.AddApplicationIdentity();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.MapRazorPages();

            await app.CreateAdminRoleAsync();

            await app.RunAsync();
        }
    }
}