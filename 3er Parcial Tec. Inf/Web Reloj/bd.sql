
/****** Object:  User [PC-PC\INVITADO]    Script Date: 24/10/2020 09:18:12 a.m. ******/
CREATE USER [PC-PC\INVITADO] FOR LOGIN [PC-PC\INVITADO] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 24/10/2020 09:18:12 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuenta] [varchar](max) NULL,
	[idproducto] [int] NULL,
	[cantidad] [numeric](10, 2) NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(10,1) NOT NULL,
	[descripcion] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuenta] [varchar](max) NULL,
	[monto] [numeric](10, 2) NULL,
	[fecha] [date] NULL,
	[hora] [varchar](10) NULL,
	[estado] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Compra]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Compra](
	[cuenta] [varchar](max) NULL,
	[id_producto] [int] NULL,
	[cantidad] [numeric](10, 2) NULL,
	[precio] [numeric](10, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(10000,1) NOT NULL,
	[nombre] [varchar](max) NULL,
	[descripcion] [varchar](max) NULL,
	[imagen] [varchar](max) NULL,
	[precio] [numeric](10, 2) NULL,
	[idCategoria] [int] NULL,
	[ubicacion] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[UserName] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Status] [int] NULL,
	[Perfil] [int] NULL,
	[Nombre] [varchar](max) NULL,
	[WhatsApp] [varchar](max) NULL,
	[Telefono] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Buscar_Categoria]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Buscar_Categoria]
 AS 
  select TOP 1000 *from Categoria where descripcion != 'Sin Categoria' order by descripcion
GO
SET IDENTITY_INSERT [dbo].[Carrito] ON 

INSERT [dbo].[Carrito] ([id], [cuenta], [idproducto], [cantidad], [fecha]) VALUES (24, N'Jimenez', 10047, CAST(36.00 AS Numeric(10, 2)), CAST(N'2020-09-10' AS Date))
SET IDENTITY_INSERT [dbo].[Carrito] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([idCategoria], [descripcion]) VALUES (10, N'Sin Categoria')
INSERT [dbo].[Categoria] ([idCategoria], [descripcion]) VALUES (11, N'Granos y Cereales')
INSERT [dbo].[Categoria] ([idCategoria], [descripcion]) VALUES (12, N'Lacteos')
INSERT [dbo].[Categoria] ([idCategoria], [descripcion]) VALUES (13, N'Carnes')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Compra] ON 

INSERT [dbo].[Compra] ([id], [cuenta], [monto], [fecha], [hora], [estado]) VALUES (10, N'Jimenez', CAST(1416.00 AS Numeric(10, 2)), CAST(N'2020-08-07' AS Date), N'  4:56PM', N'Disponible')
INSERT [dbo].[Compra] ([id], [cuenta], [monto], [fecha], [hora], [estado]) VALUES (11, N'antony', CAST(500.00 AS Numeric(10, 2)), CAST(N'2020-08-10' AS Date), N'02:30PM', N'Despacho')
INSERT [dbo].[Compra] ([id], [cuenta], [monto], [fecha], [hora], [estado]) VALUES (12, N's4', CAST(700.00 AS Numeric(10, 2)), CAST(N'2020-08-10' AS Date), N'02:35PM', N'Pendiente')
INSERT [dbo].[Compra] ([id], [cuenta], [monto], [fecha], [hora], [estado]) VALUES (13, N'Jimenez', CAST(45.00 AS Numeric(10, 2)), CAST(N'2020-08-10' AS Date), N'  3:30PM', N'Pendiente')
SET IDENTITY_INSERT [dbo].[Compra] OFF
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'antony', 10055, CAST(1.00 AS Numeric(10, 2)), CAST(52.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'antony', 10056, CAST(2.00 AS Numeric(10, 2)), CAST(184.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'antony', 10047, CAST(8.00 AS Numeric(10, 2)), CAST(45.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'antony', 10056, CAST(5.00 AS Numeric(10, 2)), CAST(184.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'Jimenez', 10055, CAST(3.00 AS Numeric(10, 2)), CAST(52.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'Jimenez', 10047, CAST(3.00 AS Numeric(10, 2)), CAST(45.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'Jimenez', 10052, CAST(25.00 AS Numeric(10, 2)), CAST(45.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'Jimenez', 10055, CAST(3.00 AS Numeric(10, 2)), CAST(52.00 AS Numeric(10, 2)))
INSERT [dbo].[Detalle_Compra] ([cuenta], [id_producto], [cantidad], [precio]) VALUES (N'Jimenez', 10052, CAST(1.00 AS Numeric(10, 2)), CAST(45.00 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [imagen], [precio], [idCategoria], [ubicacion]) VALUES (10047, N'Arroz Pinco', N'Libra', N'https://cdn.shopify.com/s/files/1/0123/4455/7664/products/PIMCO-ARROZ-PREMIUM-10-LB-codigo-7464510500109.jpg?v=1585850420', CAST(45.00 AS Numeric(10, 2)), 0, N'N')
INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [imagen], [precio], [idCategoria], [ubicacion]) VALUES (10052, N'Arroz Pinco', N'Libra', N'https://cdn.shopify.com/s/files/1/0123/4455/7664/products/PIMCO-ARROZ-PREMIUM-10-LB-codigo-7464510500109.jpg?v=1585850420', CAST(45.00 AS Numeric(10, 2)), 0, N'N')
INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [imagen], [precio], [idCategoria], [ubicacion]) VALUES (10055, N'maiz', N'dulce', N'https://i.ebayimg.com/images/g/dBEAAOSwa2pbNIn0/s-l1600.jpg', CAST(52.00 AS Numeric(10, 2)), 13, N'P5-3-L')
INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [imagen], [precio], [idCategoria], [ubicacion]) VALUES (10056, N'Pargo Rojo', N'Libra', N'https://www.copesur.com.pe/admin/_uploads/imagenes/17042018225706-caballa-entera.jpg', CAST(184.00 AS Numeric(10, 2)), 13, N'N')
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([ID], [UserName], [Password], [Status], [Perfil], [Nombre], [WhatsApp], [Telefono], [Direccion]) VALUES (1000, N's4', N'wwwwww', 1, 1, N'Roma 7', N'8095555555', N'8095816666', N'gurabito')
INSERT [dbo].[Usuarios] ([ID], [UserName], [Password], [Status], [Perfil], [Nombre], [WhatsApp], [Telefono], [Direccion]) VALUES (1001, N'Jimenez', N'123123', 1, 1, N'juan 2', N'8095555555', N'8095816666', N'las colinas calle ')
INSERT [dbo].[Usuarios] ([ID], [UserName], [Password], [Status], [Perfil], [Nombre], [WhatsApp], [Telefono], [Direccion]) VALUES (1002, N'antony', N'123123', 1, 1, N'Antony Mota Rivas', N'8098524048', N'8095816667', N'la cienaga villa emilia numero 89')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  StoredProcedure [dbo].[AgregarCarrito]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AgregarCarrito]
@cuenta varchar(max),
@idproducto int,
@cantidad numeric(10,2)
as
if not exists(select idproducto from Carrito where cuenta = @cuenta and idproducto = @idproducto)
 insert into Carrito values(@cuenta,@idproducto,@cantidad,getdate())
 else
 begin
 declare @cant numeric(10,2)
 select  @cant = cantidad from Carrito where cuenta = @cuenta and idproducto = @idproducto
 update Carrito set cantidad = @cant + @cantidad, fecha = getdate() where cuenta = @cuenta and idproducto = @idproducto
 end
GO
/****** Object:  StoredProcedure [dbo].[AgregarProductos]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AgregarProductos]
@codigo varchar(max),
@nombre varchar(max),
@descripcion varchar(max),
@imagen varchar(max),
@precio numeric(10,2),
@idcategoria int,
@ubicacion varchar(max)
as
if @codigo = 'N'
insert into Productos values(@nombre,@descripcion,@imagen,@precio,@idCategoria,@ubicacion)
else
update Productos set nombre = @nombre, descripcion = @descripcion, precio = @precio,imagen = @imagen,ubicacion = @ubicacion where id = @codigo
GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuarios]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AgregarUsuarios]
@Tipo int,
@UserName varchar(max),
@Password varchar(max),
@Nombre varchar(max),
@WhatsApp varchar(max),
@Telefono varchar(max),
@Direccion varchar(max)
as
if @Tipo = 0
insert into Usuarios values(@UserName,@Password,1,1,@Nombre ,@WhatsApp,@Telefono,@Direccion)
else if @Tipo = 1
update Usuarios set Nombre = @Nombre, WhatsApp = @WhatsApp, Telefono = @Telefono, Direccion =@Direccion where UserName = @UserName
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductos]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ConsultarProductos]
as
select *from Productos
GO
/****** Object:  StoredProcedure [dbo].[inserta_compra]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[inserta_compra]
	@cuenta varchar(max),
	@monto numeric(10,2)
	as
	declare @hora varchar(10)SELECT  distinct @hora = RIGHT( CONVERT(DATETIME, SYSDATETIME(), 108),8)
		insert into Compra values(@cuenta,@monto,GETDATE(),@hora,'Pendiente')
GO
/****** Object:  StoredProcedure [dbo].[inserta_detalle_compra]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[inserta_detalle_compra]
		@cuenta varchar(max),
		@id_producto int,
		@cantidad numeric(10,2),
		@precio numeric(10,2)
		AS
		insert into detalle_compra values(
		@cuenta,
		@id_producto,
		@cantidad,
		@precio
		)
GO
/****** Object:  Trigger [dbo].[inserta_detalles_compra]    Script Date: 24/10/2020 09:18:13 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[inserta_detalles_compra]
ON [dbo].[Compra] FOR INSERT 
AS
	declare	@cuenta varchar(max)

SET @cuenta = (SELECT cuenta FROM Inserted)
insert Into Detalle_Compra select c.cuenta,c.idproducto,c.cantidad,p.precio From Carrito c inner join Productos p 
on c.idproducto = p.id Where cuenta = @cuenta

delete from Carrito  Where cuenta = @cuenta
GO
ALTER TABLE [dbo].[Compra] ENABLE TRIGGER [inserta_detalles_compra]
GO
