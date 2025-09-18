create database adminpc;
go 
use adminpc;
go 

create table [Componentes](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
);
create table [garantias](
	[Id] int not null identity(1,1) primary key,
	[Fecha_inicio] smalldatetime default getdate() not null,
	[Fecha_fin] smalldatetime not null,
);

create table [Marcas](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
);

create table [Computadores](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Modelo] nvarchar(100) not null,
	[Precio] decimal not null,
	[Marca] int references [Marcas]([Id]) not null,
	[Componente] int references [Componentes]([Id]) not null
);

create table [Clientes](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Apellido] nvarchar(50) not null,
	[Cedula] nvarchar(11) not null,
	[Correo] nvarchar(70) not null,
	[Computador] int references [Computadores]([Id]) not null,
);

create table [Puestos](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
	[Salario] decimal not null,
);

create table [Empleados](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Apellido] nvarchar(50) not null,
	[Cedula] nvarchar(11) not null,
	[Correo] nvarchar(70) not null,
	[Puesto] int references [Puestos]([Id]) not null
);




create table [Servicios](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
	[Precio] decimal not null,
);

create table [Orden_servicios](
	[Id] int not null identity(1,1) primary key,
	[Estado] bit not null,
	[Fecha] smalldatetime not null,
	[Precio] decimal not null,
	[Servicio] int references [Servicios]([Id]) not null,
	[Cliente] int references [Clientes]([Id]) not null,
	[Empleado] int references [Empleados]([Id]) not null,
);

create table [Productos](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
	[Garantia] int references [Garantias]([Id]) not null,
);
create table [Pagos](
	[Id] int not null identity(1,1) primary key,
	[Fecha] smalldatetime not null,
	[Monto] decimal not null,
	[Tipo_pago] nvarchar(60) not null,

);

create table [Facturas](
	[Id] int not null identity(1,1) primary key,
	[Fecha] smalldatetime not null,
	[Descripcion] nvarchar(100) not null,
	[Valor_total] decimal not null,
	[Pago] int references [Pagos]([Id]) not null,
	[Garantia] int references [Garantias]([Id]) not null,
	[Orden] int references [Orden_servicios]([Id]) not null,

);

create table [Inventarios](
	[Id] int not null identity(1,1) primary key,
	[Descripcion] nvarchar(100) not null,
	[Piezas_disponibles] int not null,
	[Producto] int references [Productos]([Id]) not null,
);
use adminpc
create table [Orden_productos](
	[Id] int not null identity(1,1) primary key,
	[Cantidad] int not null,
	[Producto] int references [Productos]([Id]) not null,
	[Orden] int references [Orden_servicios]([Id]) not null,
);



create table [Proveedores](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Correo] nvarchar(100) not null,
	[Telefono] nvarchar(11) not null,
	[Producto] int references [Productos]([Id]) not null,
);

INSERT INTO Componentes (Nombre, Descripcion) VALUES
('RAM 8GB', 'Memoria DDR4 8GB'),
('SSD 256GB', 'Unidad estado sólido'),
('Fuente 500W', 'Fuente de poder genérica'),
('Placa Base A320', 'Motherboard básica'),
('Tarjeta Gráfica GTX1050', 'GPU Nvidia GTX 1050');

INSERT INTO Garantias (Fecha_inicio, Fecha_fin) VALUES
(GETDATE(), DATEADD(year, 1, GETDATE())),
(GETDATE(), DATEADD(year, 2, GETDATE())),
(GETDATE(), DATEADD(month, 6, GETDATE())),
(GETDATE(), DATEADD(year, 3, GETDATE())),
(GETDATE(), DATEADD(day, 90, GETDATE()));

INSERT INTO Marcas (Nombre, Descripcion) VALUES
('Lenovo', 'Fabricante de computadores'),
('HP', 'Hewlett Packard'),
('Dell', 'Dell Computers'),
('Asus', 'AsusTek'),
('Acer', 'Acer Inc.');

INSERT INTO Puestos (Nombre, Descripcion, Salario) VALUES
('Técnico', 'Soporte técnico de PCs', 1200),
('Vendedor', 'Atención al cliente', 1000),
('Administrador', 'Encargado de tienda', 2000),
('Mensajero', 'Entrega de productos', 900),
('Gerente', 'Dirección general', 3000);

INSERT INTO Servicios (Nombre, Descripcion, Precio) VALUES
('Mantenimiento', 'Limpieza y diagnóstico', 50),
('Reparación', 'Reemplazo de componentes', 100),
('Instalación SO', 'Instalación de Windows/Linux', 80),
('Optimización', 'Mejora de rendimiento', 40),
('Backup', 'Copia de seguridad', 30);

INSERT INTO Pagos (Fecha, Monto, Tipo_pago) VALUES
(GETDATE(), 500, 'Efectivo'),
(GETDATE(), 1200, 'Tarjeta crédito'),
(GETDATE(), 800, 'Transferencia'),
(GETDATE(), 300, 'Efectivo'),
(GETDATE(), 1000, 'Tarjeta débito');

INSERT INTO Computadores (Nombre, Modelo, Precio, marca, componente) VALUES
('ThinkPad', 'T14', 1200, 1, 1),
('Pavilion', '15-ec', 1000, 2, 2),
('Inspiron', '3505', 900, 3, 3),
('VivoBook', 'X515', 1100, 4, 4),
('Aspire', 'A315', 850, 5, 5);

-- 8. Clientes (requiere Computadores)
INSERT INTO Clientes (Nombre, Apellido, Cedula, Correo, computador) VALUES
('Juan', 'Pérez', '1002003001', 'juan@example.com', 1),
('Ana', 'Gómez', '1002003002', 'ana@example.com', 2),
('Luis', 'Martínez', '1002003003', 'luis@example.com', 3),
('Carla', 'López', '1002003004', 'carla@example.com', 4),
('Pedro', 'Ramírez', '1002003005', 'pedro@example.com', 5);

INSERT INTO Empleados (Nombre, Apellido, Cedula, Correo, puesto) VALUES
('Mario', 'Torres', '2003004001', 'mario@example.com', 1),
('Lucía', 'Ríos', '2003004002', 'lucia@example.com', 2),
('Carlos', 'Vega', '2003004003', 'carlos@example.com', 3),
('Fernanda', 'Quintero', '2003004004', 'fernanda@example.com', 4),
('Andrés', 'Moreno', '2003004005', 'andres@example.com', 5);

INSERT INTO Productos (Nombre, Descripcion, garantia) VALUES
('Mouse', 'Mouse óptico inalámbrico', 1),
('Teclado', 'Teclado mecánico retroiluminado', 2),
('Monitor', 'Monitor LED 24 pulgadas', 3),
('Impresora', 'Impresora multifuncional', 4),
('Parlantes', 'Parlantes estéreo 2.0', 5);

INSERT INTO Inventarios (Descripcion, Piezas_disponibles, producto) VALUES
('Inventario Mouse', 50, 1),
('Inventario Teclado', 30, 2),
('Inventario Monitor', 20, 3),
('Inventario Impresora', 10, 4),
('Inventario Parlantes', 25, 5);

INSERT INTO Orden_servicios (Estado, Fecha, Precio, servicio, cliente, empleado) VALUES
(1, GETDATE(), 60, 1, 1, 1),
(0, GETDATE(), 120, 2, 2, 2),
(1, GETDATE(), 90, 3, 3, 3),
(1, GETDATE(), 40, 4, 4, 4),
(0, GETDATE(), 35, 5, 5, 5);

INSERT INTO Orden_productos (Cantidad, Producto, orden) VALUES
(2, 1, 1),
(1, 2, 2),
(3, 3, 3),
(1, 4, 4),
(5, 5, 5);

INSERT INTO Facturas (Fecha, Descripcion, Valor_total, pago, garantia, orden) VALUES
(GETDATE(), 'Factura mantenimiento', 500, 1, 1, 1),
(GETDATE(), 'Factura reparación', 1200, 2, 2, 2),
(GETDATE(), 'Factura instalación SO', 800, 3, 3, 3),
(GETDATE(), 'Factura optimización', 300, 4, 4, 4),
(GETDATE(), 'Factura backup', 1000, 5, 5, 5);


INSERT INTO Proveedores (Nombre, correo, telefono, Producto) VALUES
('Proveedor1', 'prov1@example.com', '3001234567', 1),
('Proveedor2', 'prov2@example.com', '3002345678', 2),
('Proveedor3', 'prov3@example.com', '3003456789', 3),
('Proveedor4', 'prov4@example.com', '3004567890', 4),
('Proveedor5', 'prov5@example.com', '3005678901', 5);