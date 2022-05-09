using BusinessLogic;
using DataAcessLayar.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Startup
    {
        private const string CorsPolicy = "corsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // System depndency
            services.AddCors();
            services.AddControllers();
            // Set up CORS
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                {
                    builder
                       .SetIsOriginAllowed(org => true) // Check that origin is allowed predicate
                       .AllowAnyHeader() //Allow any headers in requests
                       .AllowAnyMethod() // Allow any methods (HTTPGet, HTTPPost, etc)
                       .AllowCredentials(); //Allows user creds

                });
            });

            // Package depndency
            // Castom dependency
            ConfigureDatabase(services);
            services.RegisterBusinessLogicServices();
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            // TODO: read connection string from settings.json
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TestAppDb;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseCors(CorsPolicy);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/index.html");
            });
        }
    }
}
