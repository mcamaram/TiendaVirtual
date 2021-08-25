using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TiendaVirtual.Service;
using TiendaVirtual.Service.Contract;
using TiendaVirtual.Service.Service;
using TiendaVirtual.UnitOfWork.DB;
using TiendaVirtual.UnitOfWork.Interface;

namespace TiendaVirtual
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
            services.AddControllersWithViews();
            services.AddTransient<IUnitOfWork, UnitOfWorkDB>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IMarcaService, MarcaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProductoService, ProductoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
