using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorio.Implementaciones;
using lib_repositorios.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagosController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<Pagos> Get()
        {
            var conexion = new Conexion();
            conexion.StringConexion = "server=localhost\\DEV;database=trabajo;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();
            return new List<Pagos>();
        }

        private PagosAplicacion? iAplicacion;
        public PagosController(PagosAplicacion? iAplicacion/*, TokenController tokenController*/)
        {
            this.iAplicacion = iAplicacion;
            //this.tokenController = tokenController;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost("Listar")]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                string conexionstring = "server=localhost\\DEV;database=trabajo;Integrated Security=True;TrustServerCertificate=true;";
                this.iAplicacion!.Configurar(conexionstring);

                respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }


        [HttpPost("Guardar")]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Pagos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                string conexionstring = "server=localhost\\DEV;database=trabajo;Integrated Security=True;TrustServerCertificate=true;";
                this.iAplicacion!.Configurar(conexionstring);

                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost("Modificar")]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Pagos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                string conexionstring = "server=localhost\\DEV;database=trabajo;Integrated Security=True;TrustServerCertificate=true;";
                this.iAplicacion!.Configurar(conexionstring);

                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost("Borrar")]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Pagos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                string conexionstring = "server=localhost\\DEV;database=trabajo;Integrated Security=True;TrustServerCertificate=true;";
                this.iAplicacion!.Configurar(conexionstring);


                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

    }
}
