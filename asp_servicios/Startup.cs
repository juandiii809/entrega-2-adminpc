using asp_servicios.Controllers;
using lib_repositorio.Implementaciones;
using lib_repositorio.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IMarcasAplicacion, MarcasAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<IComponentesAplicacion, ComponentesAplicacion>();
            services.AddScoped<IComputadoresAplicacion, ComputadoresAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IGarantiasAplicacion, GarantiasAplicacion>();
            services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();
            services.AddScoped<IOrden_productosAplicacion, Orden_productosAplicacion>();
            services.AddScoped<IOrden_serviciosAplicacion, Orden_serviciosAplicacion>();
            services.AddScoped<IPagosAplicacion, PagosAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<IPuestosAplicacion, PuestosAplicacion>();
            services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();
            services.AddScoped<TokenAplicacion, TokenAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();
            //services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/", () => "entrega proyecto");
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
