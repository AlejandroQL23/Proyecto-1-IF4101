USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[CreateCourse]    Script Date: 26/5/2021 11:27:42 ******/
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


--------------------------------------------------------




USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[CreateProfessor]    Script Date: 26/5/2021 11:29:21 ******/
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


--------------------------------------------------------

USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 26/5/2021 11:29:57 ******/
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



--------------------------------------------------------



USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 26/5/2021 11:30:52 ******/
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





--------------------------------------------------------





USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[ReadCourse]    Script Date: 26/5/2021 11:31:49 ******/
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



--------------------------------------------------------




USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[ReadStudents]    Script Date: 26/5/2021 11:32:37 ******/
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



--------------------------------------------------------


USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[SelectCourseGeneral]    Script Date: 26/5/2021 11:34:31 ******/
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



--------------------------------------------------------


USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[SelectStudentByID]    Script Date: 26/5/2021 11:35:02 ******/
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


--------------------------------------------------------


USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 26/5/2021 11:35:28 ******/
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



--------------------------------------------------------


USE [ALDIFA_SOFT_MVC_IF4101]
GO

/****** Object:  StoredProcedure [dbo].[UpdateStudentApproval]    Script Date: 26/5/2021 11:36:04 ******/
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
	 if(@Approval ='' OR @Approval ='0')
	 UPDATE [dbo].[User] SET Approval = 'En Espera'
	 WHERE IdCard = @IdCard
END
GO







