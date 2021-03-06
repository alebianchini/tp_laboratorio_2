USE [master]
GO
/****** Object:  Database [Mensajeria]    Script Date: 24/11/2020 19:06:17 ******/
CREATE DATABASE [Mensajeria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mensajeria', FILENAME = N'F:\SQLEXPRESS\MSSQL15.SQLEXPRESS\MSSQL\DATA\Mensajeria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mensajeria_log', FILENAME = N'F:\SQLEXPRESS\MSSQL15.SQLEXPRESS\MSSQL\DATA\Mensajeria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Mensajeria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mensajeria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mensajeria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mensajeria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mensajeria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mensajeria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mensajeria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mensajeria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mensajeria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mensajeria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mensajeria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mensajeria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mensajeria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mensajeria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mensajeria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mensajeria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mensajeria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mensajeria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mensajeria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mensajeria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mensajeria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mensajeria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mensajeria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mensajeria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mensajeria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mensajeria] SET  MULTI_USER 
GO
ALTER DATABASE [Mensajeria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mensajeria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mensajeria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mensajeria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mensajeria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mensajeria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Mensajeria] SET QUERY_STORE = OFF
GO
USE [Mensajeria]
GO
/****** Object:  Table [dbo].[PedidosEntregados]    Script Date: 24/11/2020 19:06:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidosEntregados](
	[Codigo] [varchar](50) NOT NULL,
	[PrecioFinal] [float] NOT NULL,
	[Delivery] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-30', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-31', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-32', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-33', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-34', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-35', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-36', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-37', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-38', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'18-16-39', 550, N'false', N'no es para llevar')
INSERT [dbo].[PedidosEntregados] ([Codigo], [PrecioFinal], [Delivery], [Direccion]) VALUES (N'19-01-05', 550, N'false', N'no es para llevar')
GO
USE [master]
GO
ALTER DATABASE [Mensajeria] SET  READ_WRITE 
GO
