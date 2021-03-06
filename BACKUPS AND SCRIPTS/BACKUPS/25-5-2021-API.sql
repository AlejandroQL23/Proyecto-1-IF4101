USE [master]
GO
/****** Object:  Database [ALDIFA_SOFT_API_IF4101]    Script Date: 25/5/2021 22:37:46 ******/
CREATE DATABASE [ALDIFA_SOFT_API_IF4101]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALDIFA_SOFT_API_IF4101', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_API_IF4101.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ALDIFA_SOFT_API_IF4101_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_API_IF4101_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[News]    Script Date: 25/5/2021 22:37:47 ******/
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
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsComment]    Script Date: 25/5/2021 22:37:47 ******/
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
 CONSTRAINT [PK_NewsComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate]) VALUES (3, N'George', N'Tercera', N'turismo talo los arboles de los pollitos para hacer papel higienico yq ue por fin haya en los baños', N'Derechos estudiantiles', 0x, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate]) VALUES (4, N'Administrador', N'Biblio', N'menttirra', N'Guias de horario', 0x, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate]) VALUES (7, N'Administrador', N'weshannnn', N'City CAMPEONNNN', N'Guias de horario', NULL, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[News] ([Id], [Author], [Title], [TextContent], [Category], [ExtraFile], [CreationDate]) VALUES (13, N'Administrador', N'Mas cupos', N' Se dieron mas cupos en calculo', N'Guias de horario', 0x, CAST(N'2021-05-25' AS Date))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsComment] ON 

INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (1, N'Popeye', N'que bonita noticias', 1, CAST(N'2021-05-22' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (2, N'Spidi Gonzales', N'hola amigues, ami no me gusta ese notesee', 2, CAST(N'2021-05-22' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (3, N'Lalo Garza', N'Krillinnnnnn', 4, CAST(N'2021-05-22' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (4, N'Papaya', N'que fea noticias', 5, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (5, N'Andres Coto Serrano', N'deede', 3, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (6, N'Francisco Vega', N'no me gusta esta noticia, abajo el patriarcado', 4, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (7, N'George Harrison', N'yo repoyo la Uelga de hambre', 9, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (8, N'Diego Garita Abarca', N'estoy comentando la tres', 3, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (9, N'Ale QL', N'xd', 4, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (10, N'Ale Q', N'naniiiii', 2, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[NewsComment] ([Id], [Author], [TextContent], [NewsId], [CreationDate]) VALUES (11, N'Diego Garita Abarca', N'muy bonita', 4, CAST(N'2021-05-25' AS Date))
SET IDENTITY_INSERT [dbo].[NewsComment] OFF
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF__NewsFile]  DEFAULT (0x) FOR [ExtraFile]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [US_CreationDateNews]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[NewsComment] ADD  CONSTRAINT [US_CreationDateNewsComment]  DEFAULT (getdate()) FOR [CreationDate]
GO
USE [master]
GO
ALTER DATABASE [ALDIFA_SOFT_API_IF4101] SET  READ_WRITE 
GO
