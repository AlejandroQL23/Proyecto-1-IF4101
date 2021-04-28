USE ALDIFA_SOFT_MVC_IF4101;
GO

--Query utilizado el 27/4/2021


CREATE TABLE [dbo].[Administrator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Last_Name] [nvarchar](70) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](20) NOT NULL)
	GO

---------
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
	[Presidency] [bit] NOT NULL,
	[Activity] [bit] NOT NULL,
	[Approval] [nvarchar](15) NOT NULL,
	[Profile_Picure] [text] NULL,
	[Creation_Date] [date] NULL)
	GO

---------

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
	[Activity] [bit] NOT NULL)
	GO
	--------------------------------------

	CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Initials] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Credits] [int] NOT NULL,
	[Activity] [bit] NOT NULL,
	[Semester] [nvarchar](3) NOT NULL,
	[Schedule] [nvarchar](200) NULL)
	GO

-----------------------------------------------------
--esto con todos los elementos null necesarios
ALTER TABLE [dbo].[Student] ALTER COLUMN [Activity] BIT NOT NULL;
GO
-----
-----
ALTER TABLE [dbo].[Student]
ADD Creation_Date Date NULL
GO 
---------
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT DF_CreationDateStudent DEFAULT GETDATE() FOR Creation_Date
GO 

ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT S_DefaultState DEFAULT 'en espera' FOR Approval
GO

ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT S_DefaultRol DEFAULT 'Estudiante' FOR Rol
GO

ALTER TABLE [dbo].[Administrator]
ADD CONSTRAINT A_DefaultRol DEFAULT 'Administrador' FOR Rol
GO
------------------------------
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT GR_CreationDateGroup DEFAULT GETDATE() FOR Creation_Date
GO 
------------------------------

ALTER TABLE [dbo].[Course]
ADD CONSTRAINT CO_CreationDateCourse DEFAULT GETDATE() FOR Creation_Date
GO 


------------------------------
ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT S_DefaultActivity DEFAULT '1' FOR Activity
GO

ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT S_DefaultPresidency DEFAULT '0' FOR Presidency
GO

-------------------------------

ALTER TABLE [dbo].[Student] DROP CONSTRAINT S_DefaultActivity;

ALTER TABLE [dbo].[Student] DROP CONSTRAINT S_DefaultPresidency;
GO
-------------------------------
DELETE FROM [dbo].[Student]

ALTER TABLE [dbo].[Student]
ADD CHECK ([Email] LIKE '%@gmail.com')
GO
-------------------------------


CREATE PROCEDURE CreateStudent @Id_Card nvarchar(8), @Name varchar(20),
@Last_Name varchar (70), @Email nvarchar(70), @Password nvarchar(70),
@Phone nvarchar(8), @Address nvarchar(100)
AS
BEGIN

INSERT INTO Student (Id_Card, [Name], Last_Name, Email, [Password], Phone, [Address])
VALUES (@Id_Card, @Name,@Last_Name,@Email,@Password,@Phone,@Address)
END

--------------------------------

CREATE PROCEDURE VerifyEmail
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










