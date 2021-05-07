USE [master]
GO
/****** Object:  Database [ALDIFA_SOFT_MVC_IF4101]    Script Date: 5/5/2021 23:10:04 ******/
CREATE DATABASE [ALDIFA_SOFT_MVC_IF4101]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALDIFA_SOFT_MVC_IF4101', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_MVC_IF4101.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ALDIFA_SOFT_MVC_IF4101_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_MVC_IF4101_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ALDIFA_SOFT_MVC_IF4101].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ARITHABORT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET  MULTI_USER 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET QUERY_STORE = OFF
GO
USE [ALDIFA_SOFT_MVC_IF4101]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ALDIFA_SOFT_MVC_IF4101]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Initials] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Credits] [int] NOT NULL,
	[Semester] [nvarchar](8) NULL,
	[Schedule_Id] [int] NULL,
	[Activity] [bit] NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NULL,
	[CreationUser] [nvarchar](15) NULL,
	[UpdateUser] [nvarchar](15) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](5) NOT NULL,
	[Course_Id] [int] NULL,
	[Main_Professor_Id] [int] NULL,
	[Schedule_Id] [int] NULL,
	[Creation_Date] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCard] [nvarchar](8) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](20) NULL,
	[Phone] [nvarchar](15) NULL,
	[Address] [nvarchar](100) NULL,
	[Activity] [bit] NULL,
	[Approval] [nvarchar](15) NULL,
	[Presidency] [bit] NULL,
	[PersonalFormation] [nvarchar](100) NULL,
	[DateTime] [nvarchar](100) NULL,
	[Instagram] [nvarchar](70) NULL,
	[Facebook] [nvarchar](70) NULL,
	[Picture] [text] NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NULL,
	[CreationUser] [nvarchar](20) NULL,
	[UpdateUser] [nvarchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__User__3B7B33C35C2288B7] UNIQUE NONCLUSTERED 
(
	[IdCard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [CO_CreationDateCourse]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [Co_DefaultCreation]  DEFAULT ('Administrador') FOR [CreationUser]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [GR_CreationDateGroup]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [US_CreationDateStudent]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [CK_UserEmail] CHECK  (([Email] like '%@gmail.com'))
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [CK_UserEmail]
GO
/****** Object:  StoredProcedure [dbo].[CreateCourse]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCourse] @Initials nvarchar(10), @Name nvarchar(50),
@Credits int, @Semester nvarchar(8), @Schedule_Id int, @Activity bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO Course (Initials,[Name], Credits,Semester,Schedule_Id,Activity)
VALUES (@Initials,@Name,@Credits,@Semester,@Schedule_Id,@Activity)
UPDATE [dbo].[Course]
SET CreationUser = @Name, UpdateUser = 'N/A'

WHERE Initials=@Initials;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateProfessor]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateProfessor] @IdCard nvarchar(8),@Name nvarchar(20),
@LastName nvarchar(70), @Email nvarchar(50), @Password nvarchar(50),
@Phone nvarchar(8), @Address nvarchar(100)
AS
BEGIN

INSERT INTO [dbo].[User] (IdCard, [Name], LastName, Email, [Password], Phone, [Address])
VALUES (@IdCard, @Name,@LastName,@Email,@Password,@Phone,@Address)
UPDATE [User]
SET Activity = 1, Approval = 'Aceptado' , Presidency=0, Rol ='Profesor',
CreationUser = 'Administrador', UpdateUser = 'N/A'
WHERE IdCard = @IdCard;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateStudent] @IdCard nvarchar(8), @Name varchar(20),
@LastName varchar (50), @Email nvarchar(50), @Password nvarchar(50),
@Phone nvarchar(15), @Address nvarchar(100)
AS
BEGIN


INSERT INTO [User] (IdCard, [Name], LastName, Email, [Password], Phone, [Address])
VALUES (@IdCard, @Name,@LastName,@Email,@Password,@Phone,@Address)
UPDATE [User]
SET Activity = 0, Approval = 'En Espera' , Presidency=0, Rol ='Estudiante',
CreationUser = @Name, UpdateUser = 'N/A', [DateTime] = 'N/A'

WHERE IdCard = @IdCard;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--se elimina con la ID y las siglas del curso
CREATE PROCEDURE [dbo].[DeleteCourse] @Initials NVARCHAR(10)
AS 
  BEGIN 
      DELETE Course
      WHERE 
	  Initials = @Initials; 
END
GO
/****** Object:  StoredProcedure [dbo].[LoginAuthentication]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LoginAuthentication]
	@IdCard NVARCHAR(8), @Password NVARCHAR(50) 

AS
BEGIN
DECLARE @Exists INT
If EXISTS(SELECT Id FROM [dbo].[User] WHERE IdCard = @IdCard AND [Password] = @Password )
	SET @Exists =  1;--si existe el usuario con las credenciales indicadas
ELSE 
BEGIN
	SET @Exists =  0;--No existe el usuario con las credenciales indicadas
END
	RETURN @Exists

END
GO
/****** Object:  StoredProcedure [dbo].[ReadCourse]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---Obtiene el curso especifico por las siglas
CREATE PROCEDURE [dbo].[ReadCourse] @Initials nvarchar(10)
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Initials], [Name], [Credits], [Semester], [Schedule_Id],[Activity]
	FROM [dbo].[Course]
	WHERE @Initials =Initials
END
GO
/****** Object:  StoredProcedure [dbo].[ReadStudents]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReadStudents]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdCard], [Name], [LastName], [Email], [Phone]
	FROM [dbo].[User]
	WHERE Approval = 'En Espera';
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCourseGeneral]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectCourseGeneral]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Initials], [Name], Credits, Semester,Activity
	FROM Course 
	 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectStudentByID]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStudentByID] (@StudentId  NVARCHAR(8)) 

AS 
  BEGIN 
       SELECT * FROM  [dbo].[User]
	  WHERE
	  
	  IdCard = @StudentId AND Rol = 'Estudiante'; 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCourse] (@Initials NVARCHAR(10),
@Name NVARCHAR(50), @Credits INTEGER, @Semester NVARCHAR(8),
 @Activity BIT) 
AS 
  BEGIN 
-- @Schedule_Id INTEGER,
            UPDATE Course 
            SET Initials = @Initials,
				[Name]= @Name,
				Credits = @Credits,
				Semester = @Semester,
				--Schedule_Id = @Schedule_Id,
				Activity = @Activity,
				UpdateUser = 'Administrador',
				UpdateDate = GETDATE()
            WHERE 
			Initials = @Initials; 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentApproval]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudentApproval] (@IdCard NVARCHAR(8), @Approval NVARCHAR(15))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	 SET NOCOUNT ON;
	 
    -- Insert statements for procedure here
	
	 UPDATE [dbo].[User] SET Approval = @Approval
	 WHERE IdCard = @IdCard
	 if(@Approval = 'Rechazado')
	 UPDATE [dbo].[User] SET Activity = 0
	 WHERE IdCard = @IdCard
	 if(@Approval = 'Aceptado')
	 UPDATE [dbo].[User] SET Activity = 1
	 WHERE IdCard = @IdCard
END
GO
/****** Object:  StoredProcedure [dbo].[VerifyEmail]    Script Date: 5/5/2021 23:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VerifyEmail]
	@Email NVARCHAR(50)

AS
BEGIN
DECLARE @Exists INT
If EXISTS(SELECT Id FROM [User] WHERE Email = @Email)
	SET @Exists =  1;
ELSE 
BEGIN
	SET @Exists =  0;
END
	RETURN @Exists

END
GO
USE [master]
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET  READ_WRITE 
GO
