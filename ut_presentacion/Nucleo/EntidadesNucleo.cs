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

        public static Garantias? Garantias()
        {
            var entidad = new Garantias();
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
            entidad.Marca = 2; // Asegúrate de que este ID exista en la base de datos
            entidad.Componente = 3; // Asegúrate de que este ID exista en la base de datos
            return entidad;

        }

        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "ajajajaja";
            entidad.Cedula = "szs";
            entidad.Correo = "sisi";
            entidad.Computador = 1;
            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "ajajajaja";
            entidad.Cedula = "szs";
            entidad.Correo = "sisi";
            entidad.Puesto = 1;
            return entidad;
        }

        public static Facturas? Facturas()
        {
            var entidad = new Facturas();
            entidad.Fecha = DateTime.Now;
            entidad.Descripcion = "pruebas";
            entidad.Valor_total = 1000000m;
            entidad.Pago = 1;
            entidad.Garantia = 1;
            entidad.Orden = 1;
            return entidad;
        }

        public static Inventarios? Inventarios()
        {
            var entidad = new Inventarios();
            entidad.Descripcion = "pruebas";
            entidad.Piezas_Disponibles = 50;
            entidad.Producto = 1;
            return entidad;
        }

        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Nombre = "pruebas";
            entidad.Descripcion = "pruebas";
            entidad.Garantia = 1;
            return entidad;
        }
    }
}
