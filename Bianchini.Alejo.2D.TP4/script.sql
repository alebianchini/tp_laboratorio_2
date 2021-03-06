USE [master]
GO
/****** Object:  Database [ProductosDB]    Script Date: 23/11/2020 07:21:07 ******/
CREATE DATABASE [ProductosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductosDB', FILENAME = N'F:\SQLEXPRESS\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductosDB_log', FILENAME = N'F:\SQLEXPRESS\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductosDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductosDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProductosDB] SET QUERY_STORE = OFF
GO
USE [ProductosDB]
GO
/****** Object:  Table [dbo].[Alimentos]    Script Date: 23/11/2020 07:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alimentos](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[PrecioUnit] [float] NOT NULL,
	[Tipo] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indumentaria]    Script Date: 23/11/2020 07:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indumentaria](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[PrecioUnit] [float] NOT NULL,
	[Talle] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alimentos] ON 

INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1001 AS Numeric(18, 0)), N'Gaseosa', 88, 110.5, N'noPerecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1002 AS Numeric(18, 0)), N'Oreo', 45, 61, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1003 AS Numeric(18, 0)), N'Carne de vaca', 19, 340.5, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1004 AS Numeric(18, 0)), N'Cereal', 21, 35.5, N'noPerecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1005 AS Numeric(18, 0)), N'Leche', 80, 50, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1006 AS Numeric(18, 0)), N'Polenta', 45, 30, N'noPerecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1007 AS Numeric(18, 0)), N'Tomate', 20, 20.5, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1008 AS Numeric(18, 0)), N'Papa', 35, 15.5, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1009 AS Numeric(18, 0)), N'Paquete fideos', 40, 43, N'noPerecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1010 AS Numeric(18, 0)), N'Cebolla', 23, 18, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1011 AS Numeric(18, 0)), N'Arroz', 19, 55, N'noPerecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1012 AS Numeric(18, 0)), N'Pan', 33, 60.5, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1013 AS Numeric(18, 0)), N'Pollo', 80, 220, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1014 AS Numeric(18, 0)), N'Lechuga', 40, 15, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1015 AS Numeric(18, 0)), N'Pepito', 26, 47, N'perecedero')
INSERT [dbo].[Alimentos] ([ID], [Nombre], [Stock], [PrecioUnit], [Tipo]) VALUES (CAST(1016 AS Numeric(18, 0)), N'Yerba', 34, 45, N'noPerecedero')
SET IDENTITY_INSERT [dbo].[Alimentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Indumentaria] ON 

INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3001 AS Numeric(18, 0)), N'Buzo Fila', N'Azul', 16, 3200, N'S')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3002 AS Numeric(18, 0)), N'Buzo Fila', N'Azul', 8, 3200, N'M')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3003 AS Numeric(18, 0)), N'Buzo Fila', N'Azul', 3, 3200, N'L')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3004 AS Numeric(18, 0)), N'Remera Adidas', N'Blanca', 20, 1400, N'S')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3005 AS Numeric(18, 0)), N'Remera Adidas', N'Blanca', 15, 1400, N'M')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3006 AS Numeric(18, 0)), N'Remera Adidas', N'Negro', 12, 1400, N'L')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3007 AS Numeric(18, 0)), N'Jean', N'Negro', 8, 2800, N'M')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3008 AS Numeric(18, 0)), N'Jean', N'Rojo', 4, 3400, N'S')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3009 AS Numeric(18, 0)), N'Remera Nike', N'Verde', 15, 1100, N'L')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3010 AS Numeric(18, 0)), N'Remera Nike', N'Verde', 6, 1100, N'M')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3011 AS Numeric(18, 0)), N'Campera Polo', N'Marron', 7, 2500, N'S')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3012 AS Numeric(18, 0)), N'Campera Polo', N'Marron', 5, 2500, N'L')
INSERT [dbo].[Indumentaria] ([ID], [Nombre], [Color], [Stock], [PrecioUnit], [Talle]) VALUES (CAST(3013 AS Numeric(18, 0)), N'asd', N'verde', 12, 2311, N'M')
SET IDENTITY_INSERT [dbo].[Indumentaria] OFF
GO
USE [master]
GO
ALTER DATABASE [ProductosDB] SET  READ_WRITE 
GO
