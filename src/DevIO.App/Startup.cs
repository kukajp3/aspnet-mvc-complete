using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevIO.Data.Context;
using AutoMapper;
using DevIO.App.Configurations;

namespace DevIO.App
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IHostEnvironment hostEnvironment)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(hostEnvironment.ContentRootPath)
          .AddJsonFile("appsettings.json", true, true)
          .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
          .AddEnvironmentVariables();

      if (hostEnvironment.IsDevelopment())
      {
        builder.AddUserSecrets<Startup>();
      }

      Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddIdentityConfiguration(Configuration);

      services.AddDbContext<DataContext>(options =>
           options.UseSqlite(
              Configuration.GetConnectionString("DefaultConnection")));

      services.AddControllersWithViews();
      services.AddRazorPages();

      services.AddAutoMapper(typeof(Startup));

      services.AddMvcConfiguration();

      services.ResolveDependecies();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
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

      app.UseGlobalizationConfiguration();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
