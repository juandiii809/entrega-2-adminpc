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
	[marca] int references [Marcas]([Id]) not null,
	[componente] int references [Componentes]([Id]) not null
);

create table [Clientes](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Apellido] nvarchar(50) not null,
	[Cedula] nvarchar(11) not null,
	[Correo] nvarchar(70) not null,
	[computador] int references [Computadores]([Id]) not null,
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
	[puesto] int references [Puestos]([Id]) not null
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
	[servicio] int references [Servicios]([Id]) not null,
	[cliente] int references [Clientes]([Id]) not null,
	[empleado] int references [Empleados]([Id]) not null,
);

create table [Productos](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[Descripcion] nvarchar(100) not null,
	[garantia] int references [Garantias]([Id]) not null,
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
	[pago] int references [Pagos]([Id]) not null,
	[garantia] int references [Garantias]([Id]) not null,
	[orden] int references [Orden_servicios]([Id]) not null,

);

create table [Inventarios](
	[Id] int not null identity(1,1) primary key,
	[Descripcion] nvarchar(100) not null,
	[Piezas_disponibles] int not null,
	[producto] int references [Productos]([Id]) not null,
);
use adminpc
create table [Orden_productos](
	[Id] int not null identity(1,1) primary key,
	[Cantidad] int not null,
	[Producto] int references [Productos]([Id]) not null,
	[orden] int references [Orden_servicios]([Id]) not null,
);



create table [Proveedores](
	[Id] int not null identity(1,1) primary key,
	[Nombre] nvarchar(30) not null,
	[correo] nvarchar(100) not null,
	[telefono] nvarchar(11) not null,
	[Producto] int references [Productos]([Id]) not null,
);