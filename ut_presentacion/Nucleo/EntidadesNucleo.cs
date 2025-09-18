using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Componentes? Componentes()
        {
            var entidad = new Componentes();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "dhfhfhh";

            return entidad;
        }

        public static Marcas? Marcas()
        {
            var entidad = new Marcas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "ajajjaja";
            return entidad;
        }
        public static Servicios? Servicios()
        {
            var entidad = new Servicios();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "ajajjaja";
            entidad.Precio = 100;
            return entidad;
        }

        public static garantias? Garantias()
        {
            var entidad = new garantias();
            entidad.Fecha_inicio = DateTime.Now;
            entidad.Fecha_fin = DateTime.Now.AddMonths(6);
            return entidad;
        }

        public static Puestos? Puestos()
        {
            var entidad = new Puestos();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "ajajjaja";
            entidad.Salario = 1000;
            return entidad;
        }

        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.Fecha = DateTime.Now.AddHours(5);
            entidad.Monto = 23.0m;
            entidad.Tipo_pago = "Efectivo";
            return entidad;
        }

        public static Computadores? Computadores()
        {
            var entidad = new Computadores();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Modelo = "ajajjaja";
            entidad.Precio = 1000;
            entidad.Marca = 9; // Asegúrate de que este ID exista en la base de datos
            entidad.Componente = 9; // Asegúrate de que este ID exista en la base de datos
            return entidad;

        }
    }
}
