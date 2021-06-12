using AuthenticationServer.BL.Classes;
using AuthenticationServer.BL.Helpers.Classes;
using AuthenticationServer.BL.Helpers.Interfaces;
using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.DAL;
using AuthenticationServer.DAL.Repositories.Classes;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.Helpers.ControllerHelpers.Classes;
using AuthenticationServer.Helpers.ControllerHelpers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationServer
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         string connectionString = "Server=DESKTOP-CLJCC9A\\SQLEXPRESS;Database=AuthenticationServerDb;Trusted_Connection=True;MultipleActiveResultSets=true";
         services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

         services.AddTransient<IRoleLogic, RoleLogic>();
         services.AddTransient<IUserLogic, UserLogic>();
         services.AddTransient<IJWTokenManager, JWTokenManager>();

         services.AddTransient<IRoleRepository, RoleRepository>();
         services.AddTransient<IUserRepository, UserRepository>();

         services.AddTransient<IAuthenticationControllerHelper, AuthenticationControllerHelper>();

         services.AddControllers();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
