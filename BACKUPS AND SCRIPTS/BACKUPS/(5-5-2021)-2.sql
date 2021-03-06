USE [master]
GO
/****** Object:  Database [ALDIFA_SOFT_MVC_IF4101]    Script Date: 5/5/2021 21:47:32 ******/
CREATE DATABASE [ALDIFA_SOFT_MVC_IF4101]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALDIFA_SOFT_MVC_IF4101', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_MVC_IF4101.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ALDIFA_SOFT_MVC_IF4101_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALDIFA_SOFT_MVC_IF4101_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ALDIFA_SOFT_MVC_IF4101', N'ON'
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET QUERY_STORE = OFF
GO
USE [ALDIFA_SOFT_MVC_IF4101]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Last_Name] [nvarchar](70) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Creation_Date] [date] NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/5/2021 21:47:32 ******/
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
	[Creation_Date] [date] NOT NULL,
	[Creation_User] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/5/2021 21:47:32 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Card] [nvarchar](8) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Last_Name] [nvarchar](70) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](8) NULL,
	[Address] [nvarchar](100) NULL,
	[Personal_Formation] [nvarchar](100) NULL,
	[Date_Time] [nvarchar](100) NULL,
	[Picture] [text] NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Activity] [bit] NOT NULL,
	[Creation_Date] [date] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_IdCardProfessor] UNIQUE NONCLUSTERED 
(
	[Id_Card] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Card] [nvarchar](8) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Last_Name] [nvarchar](70) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](8) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Instagram] [nvarchar](70) NULL,
	[Facebook] [nvarchar](70) NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Activity] [bit] NOT NULL,
	[Approval] [nvarchar](15) NOT NULL,
	[Profile_Picure] [text] NULL,
	[Creation_Date] [date] NULL,
	[Presidency] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [S_UniqueIdCard] UNIQUE NONCLUSTERED 
(
	[Id_Card] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_IdCard] UNIQUE NONCLUSTERED 
(
	[Id_Card] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrator] ADD  CONSTRAINT [A_DefaultRol]  DEFAULT ('Administrador') FOR [Rol]
GO
ALTER TABLE [dbo].[Administrator] ADD  CONSTRAINT [AD_CreationDateADMINISTRATOR]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [CO_CreationDateCourse]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [Co_DefaultCreation]  DEFAULT ('Administrador') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [GR_CreationDateGroup]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [P_DefaultRol]  DEFAULT ('Profesor') FOR [Rol]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [P_DefaultActivity]  DEFAULT ('1') FOR [Activity]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [PR_CreationDateRrofessor]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [S_DefaultRol]  DEFAULT ('Estudiante') FOR [Rol]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [S_DefaultActivity]  DEFAULT ('1') FOR [Activity]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [S_DefaultState]  DEFAULT ('En Espera') FOR [Approval]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_CreationDateStudent]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [S_DefaultPresidency]  DEFAULT ('0') FOR [Presidency]
GO
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [CK__Professor__Email__5EBF139D] CHECK  (([Email] like '%@gmail.com'))
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [CK__Professor__Email__5EBF139D]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [CK__Student__Email__5EBF139D] CHECK  (([Email] like '%@gmail.com'))
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [CK__Student__Email__5EBF139D]
GO
/****** Object:  StoredProcedure [dbo].[CreateCourse]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
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
END
GO
/****** Object:  StoredProcedure [dbo].[CreateProfessor]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateProfessor] @Id_Card nvarchar(8),@Name nvarchar(20),
@Last_Name nvarchar(70), @Email nvarchar(50), @Password nvarchar(50),
@Phone nvarchar(8), @Address nvarchar(100)
AS
BEGIN

INSERT INTO [dbo].[Professor] (Id_Card, [Name], Last_Name, Email, [Password], Phone, [Address])
VALUES (@Id_Card, @Name,@Last_Name,@Email,@Password,@Phone,@Address)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateStudent] @Id_Card nvarchar(8), @Name varchar(20),
@Last_Name varchar (70), @Email nvarchar(70), @Password nvarchar(70),
@Phone nvarchar(8), @Address nvarchar(100)
AS
BEGIN

INSERT INTO Student (Id_Card, [Name], Last_Name, Email, [Password], Phone, [Address])
VALUES (@Id_Card, @Name,@Last_Name,@Email,@Password,@Phone,@Address)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 5/5/2021 21:47:32 ******/
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
/****** Object:  StoredProcedure [dbo].[ReadCourse]    Script Date: 5/5/2021 21:47:32 ******/
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
/****** Object:  StoredProcedure [dbo].[ReadStudents]    Script Date: 5/5/2021 21:47:32 ******/
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
	SELECT [Id_Card], [Name], [Last_Name], [Email], [Phone]
	FROM [dbo].[Student]
	WHERE Approval = 'En Espera';
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCourseGeneral]    Script Date: 5/5/2021 21:47:32 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectStudentByID]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStudentByID] (@StudentId  NVARCHAR(8)) 

AS 
  BEGIN 
       SELECT * FROM Student
	  WHERE
	  -- StudentId=@StudentId; 
	  Id_Card=@StudentId; 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 5/5/2021 21:47:32 ******/
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
				Activity = @Activity

            WHERE 
			Initials = @Initials; 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentApproval]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudentApproval] (@Id_Card NVARCHAR(8), @Approval NVARCHAR(15))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	 SET NOCOUNT ON;
	 
    -- Insert statements for procedure here
	
	UPDATE [dbo].[Student] SET Approval = @Approval
	WHERE Id_Card = @Id_Card
	if(@Approval = 'Rechazado')
	 UPDATE [dbo].[Student] SET Activity = 0
	 WHERE Id_Card = @Id_Card
	-- if(@Approval = 'Aceptado')
	-- UPDATE [dbo].[Student] SET Activity = 1
	-- WHERE Id_Card = @Id_Card
END
GO
/****** Object:  StoredProcedure [dbo].[VerifyEmail]    Script Date: 5/5/2021 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VerifyEmail]
	@Email varchar(30)

AS
BEGIN
DECLARE @Exists INT
If Exists(select id from Student where Email = @Email)
	SET @Exists =  1;
else 
begin
	SET @Exists =  0;
end
	RETURN @Exists

END
GO
USE [master]
GO
ALTER DATABASE [ALDIFA_SOFT_MVC_IF4101] SET  READ_WRITE 
GO
