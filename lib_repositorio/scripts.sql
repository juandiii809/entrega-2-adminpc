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

insert into [Marcas] (Nombre, Descripcion) values
('Dell', 'Computadores de oficina y servidores'),
('HP', 'Equipos de gama media y alta'),
('Lenovo', 'Computadores de uso empresarial y gaming');

insert into [Componentes] (Nombre, Descripcion) values
('Procesador', 'Intel Core i7'),
('Memoria RAM', 'DDR4 16GB'),
('Tarjeta Gráfica', 'NVIDIA RTX 3060'),
('Disco Duro', 'SSD 512GB');

insert into [Puestos] (Nombre, Descripcion, Salario) values
('Técnico', 'Encargado de reparaciones', 1800000),
('Vendedor', 'Encargado de ventas de equipos', 1500000),
('Gerente', 'Encargado de la gestión administrativa', 3000000);

insert into [Empleados] (Nombre, Apellido, Cedula, Correo, Puesto) values
('Carlos', 'Pérez', '100000001', 'carlos.perez@adminpc.com', 1),
('Laura', 'Gómez', '100000002', 'laura.gomez@adminpc.com', 2),
('Andrés', 'Ramírez', '100000003', 'andres.ramirez@adminpc.com', 3);

insert into [Computadores] (Nombre, Modelo, Precio, Marca, Componente) values
('Dell Inspiron', 'Inspiron 3501', 2800000, 1, 1),
('HP Pavilion', 'Pavilion Gaming 15', 4200000, 2, 2),
('Lenovo ThinkPad', 'ThinkPad T14', 3800000, 3, 3);

insert into [Clientes] (Nombre, Apellido, Cedula, Correo, Computador) values
('Sofía', 'Martínez', '200000001', 'sofia.martinez@mail.com', 1),
('Juan', 'Torres', '200000002', 'juan.torres@mail.com', 2),
('Camila', 'López', '200000003', 'camila.lopez@mail.com', 3);

insert into [Servicios] (Nombre, Descripcion, Precio) values
('Mantenimiento', 'Limpieza y optimización de hardware', 100000),
('Instalación de software', 'Instalación de programas y drivers', 150000),
('Reparación', 'Reemplazo de piezas dañadas', 200000);

insert into [Orden_servicios] (Estado, Fecha, Precio, Servicio, Cliente, Empleado) values
(1, getdate(), 250000, 1, 1, 1),
(0, getdate(), 200000, 2, 2, 2),
(1, getdate(), 300000, 3, 3, 3);

insert into [Productos] (Nombre, Descripcion, Garantia) values
('Teclado mecánico', 'Teclado mecánico retroiluminado', 1),
('Mouse inalámbrico', 'Mouse inalámbrico recargable', 2),
('Monitor 24"', 'Monitor Full HD 24 pulgadas', 3);

insert into [Pagos] (Fecha, Monto, Tipo_pago) values
(getdate(), 1100000, 'Tarjeta de crédito'),
(getdate(), 300000, 'Efectivo'),
(getdate(), 50000, 'Transferencia');

insert into [Facturas] (Fecha, Descripcion, Valor_total, Pago, Garantia, Orden) values
(getdate(), 'Factura de mantenimiento y productos', 1250000, 1, 1, 1),
(getdate(), 'Factura de instalación de software', 300000, 2, 2, 2),
(getdate(), 'Factura de reparación y accesorios', 350000, 3, 3, 3);

insert into [Inventarios] (Descripcion, Piezas_disponibles, Producto) values
('Inventario de teclados mecánicos', 15, 1),
('Inventario de mouse inalámbricos', 25, 2),
('Inventario de monitores 24"', 10, 3);

insert into [Orden_productos] (Cantidad, Producto, Orden) values
(2, 1, 1), -- 2 teclados en orden 1
(1, 2, 2), -- 1 mouse en orden 2
(1, 3, 3); -- 1 monitor en orden 3

insert into [Proveedores] (Nombre, Correo, Telefono, Producto) values
('TechSupply', 'ventas@techsupply.com', '3001234567', 1),
('DistribuidoraPC', 'contacto@distribuidorapc.com', '3017654321', 2),
('ElectroMayoristas', 'ventas@electromayoristas.com', '3029876543', 3);