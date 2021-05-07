USE ALDIFA_SOFT_MVC_IF4101;
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [US_CreationDateStudent]  DEFAULT (getdate()) FOR [CreationDate]
GO

ALTER TABLE [dbo].[User] WITH CHECK ADD  CONSTRAINT [CK_UserEmail] CHECK  (([Email] like '%@gmail.com'))
GO

-----------------------------------------


CREATE PROCEDURE LoginAuthentication
	@IdCard NVARCHAR(8), @Password NVARCHAR(50) 

AS
BEGIN
DECLARE @Exists INT
If EXISTS(SELECT Id FROM [dbo].[User] WHERE IdCard = @IdCard AND [Password] = @Password )
	SET @Exists =  1;
ELSE 
BEGIN
	SET @Exists =  0;
END
	RETURN @Exists

END
GO

-----------------------------------------


CREATE PROCEDURE SelectStudentByID (@StudentId  NVARCHAR(8)) 

AS 
  BEGIN 
       SELECT * FROM  [dbo].[User]
	  WHERE
	  -- StudentId=@StudentId; 
	  IdCard = @StudentId; 
END
GO


-----------------------------------------

CREATE PROCEDURE SelectCourseGeneral
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

-----------------------------------------

CREATE PROCEDURE DeleteCourse @Initials NVARCHAR(10)
AS 
  BEGIN 
      DELETE Course
      WHERE 
	  Initials = @Initials; 
END
GO


-----------------------------------------

CREATE PROCEDURE UpdateCourse (@Initials NVARCHAR(10),
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


-----------------------------------------


ALTER TABLE [dbo].[User]
ADD UNIQUE (IdCard);
GO


-----------------------------------------



