USE [master]
GO
/****** Object:  Database [ALDIFA_SOFT_API_IF4101]    Script Date: 26/5/2021 11:58:12 ******/
CREATE DATABASE [ALDIFA_SOFT_API_IF4101]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALDIFA_SOFT_API_IF4101', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_API_IF4101.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ALDIFA_SOFT_API_IF4101_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_API_IF4101_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ALDIFA_SOFT_API_IF4101].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ARITHABORT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET  MULTI_USER 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET QUERY_STORE = OFF
GO
USE [ALDIFA_SOFT_API_IF4101]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ALDIFA_SOFT_API_IF4101]
GO
/****** Object:  Table [dbo].[News]    Script Date: 26/5/2021 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](70) NULL,
	[Title] [nvarchar](70) NULL,
	[TextContent] [nvarchar](500) NULL,
	[Category] [nvarchar](70) NULL,
	[ExtraFile] [varbinary](max) NULL,
	[CreationDate] [date] NULL,
	[CreationUser] [nvarchar](20) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsComment]    Script Date: 26/5/2021 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](70) NULL,
	[TextContent] [nvarchar](200) NULL,
	[NewsId] [int] NULL,
	[CreationDate] [date] NULL,
	[CreationUser] [nvarchar](20) NULL,
 CONSTRAINT [PK_NewsComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (3, N'Administrador', N'Siendo Ecológicos', N'La asociacion de estudiantes de Informatica empresarial hará una actividad este 29 de Junio para recolectar toda la basura del recinto y de sus alrededores púbicos, si quieres participar puedes contactarte con la presidenta actual de la asociacion', N'Recreacional', 0x, CAST(N'2021-05-21' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (4, N'Administrador', N'Biblioteca', N'La bilbioteca del recinto ha incluido unos 50 libros nuevos para el entretenimiento de los estudiantes, para poder solicitarlos, debe tener actualizado el Carné estudiantil', N'Derechos estudiantiles', 0x, CAST(N'2021-05-21' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (13, N'Administrador', N'Mas cupos', N' Se dieron mas cupos en calculo para este nuevo semestre, porfavor, tener en cuenta que estos cupos se rigen por el sistema ordinario de matricula', N'Guias de horario', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (14, N'Administrador', N'Tarde de carne', N'Este viernes a las 5 de la tarde, habrá una carne asada en el recinto, porfavor, si necesitan cubiertos, llevar los suyos propios ya que no vamos a usar ningun elemento de plastico', N'Recreacional', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (15, N'Administrador', N'Redes en exposición', N'Los estudiantes de redes estarán exponiendo su proyecto final en el liceo de Paraiso para la feria anual del colegio, esto a cargo del  coordinador de la carrera y el director del colegio, mas detalles en la pagina oficial del colegio', N'Derechos estudiantiles', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (16, N'Administrador', N'Nuevas guias de horarios 2021-II', N'Las guias de horarios de este nuevo semestre se van a publicar en una semana, el archivo estará disponible en la pagina oficial de la Sede del Atlantico', N'Guias de horario', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (17, N'Administrador', N'segundo grupo de Sistemas Operativos', N'Se comunica que el curso de Sistemas Operativos, este nuevo semestre tendra un segundo grupo debido a la demanda insuficiente', N'Guias de horario', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate], [CreationUser]) VALUES (18, N'Administrador', N'A reclamar lo nuestro', N'Este sabado habrá un webinario sobre los derechos oficiales de nosotros como estudiantes, esta reunion será dirigida por la orientadora del recinto', N'Derechos estudiantiles', 0x, CAST(N'2021-05-25' AS Date), N'Administrador')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsComment] ON 

INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (1, N'Antonio Torres Bravo', N'que bonita noticia', 1, CAST(N'2021-05-22' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (2, N'Spidi Gonzales', N'hola amigues, ami no me gusta ese notesee', 2, CAST(N'2021-05-22' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (3, N'Emily Alvarez Nuñez', N'eso me sirve demasiado, espero que si se pueda realizar y lo aprovechemos al maximo', 4, CAST(N'2021-05-22' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (4, N'Rafael Olivas Quiros', N'me parece una informacion bastante importante, ¡gracias por informar!', 5, CAST(N'2021-05-24' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (5, N'Andres Coto Serrano', N'yo apoyo este movimiento, no podemos quedarnos callados y es importante saber nuestros derechos para que no nos hagan alguna injusticia', 3, CAST(N'2021-05-24' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (6, N'Francisco Vega', N'pienso que el cuidado del ambiente es importante incluso para nuestra carrera, todos vivimos en el mismo lugar', 4, CAST(N'2021-05-24' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (7, N'George Harrison', N'eso sera bastante divertido, espero poder asistir', 9, CAST(N'2021-05-24' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (8, N'Diego Garita Abarca', N'creo que deberian poner mas de 50 libros en la biblio, me ha pasado que quiero uno pero siempre esta ocupado', 3, CAST(N'2021-05-25' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (9, N'Ale QL', N'jajaja, esperemos que el stand Up este buenisimo, pura vida ASIP', 4, CAST(N'2021-05-25' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (10, N'Ale Q', N'Que bien que estan abriendo mas cursos, eso es bastante importante para que los alumnos no se atrasen', 2, CAST(N'2021-05-25' AS Date), N'Usuario E-P')
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate], [CreationUser]) VALUES (11, N'Diego Garita Abarca', N'me parece una noticia bastante importante e interesante para todos los estudiantes de nuevos ingreso, muchas veces llegan perdidos y esta actividad les va a ayudar muchisimo', 4, CAST(N'2021-05-25' AS Date), N'Usuario E-P')
SET IDENTITY_INSERT [dbo].[NewsComment] OFF
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF__NewsFile]  DEFAULT (0x) FOR [ExtraFile]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [US_CreationDateNews]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [US_CreationUserForNews]  DEFAULT ('Administrador') FOR [CreationUser]
GO
ALTER TABLE [dbo].[NewsComment] ADD  CONSTRAINT [US_CreationDateNewsComment]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[NewsComment] ADD  CONSTRAINT [US_CreationUserForNewsComment]  DEFAULT ('Usuario E-P') FOR [CreationUser]
GO
USE [master]
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET  READ_WRITE 
GO
