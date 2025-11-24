using lib_presentacion.implementaciones;
using lib_presentacion.interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.Extensions.Options;

namespace asp_presentacion
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
            // Presentaciones
            services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IPagosPresentacion, PagosPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
            services.AddScoped<IGarantiasPresentacion, GarantiasPresentacion>();
            services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
            services.AddScoped<IComponentesPresentacion, ComponentesPresentacion>();
            services.AddScoped<IComputadoresPresentacion, ComputadoresPresentacion>();
            services.AddScoped<IPuestosPresentacion, PuestosPresentacion>();
            services.AddScoped<IServiciosPresentacion, ServiciosPresentacion>();
            services.AddScoped<IOrden_productosPresentacion, Orden_productosPresentacion>();
            services.AddScoped<IOrden_serviciosPresentacion, Orden_serviciosPresentacion>();
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<TokenAplicacion>();

            services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", options =>
            {
                options.LoginPath = "/Login";
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }
        

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            
        }
    }
}