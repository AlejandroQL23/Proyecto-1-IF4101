USE ALDIFA_SOFT_MVC_IF4101;
GO



CREATE PROCEDURE CreateProfessor @Id_Card nvarchar(8),@Name nvarchar(20),
@Last_Name nvarchar(70), @Email nvarchar(50), @Password nvarchar(50),
@Phone nvarchar(8), @Address nvarchar(100)
AS
BEGIN

INSERT INTO [dbo].[Professor] (Id_Card, [Name], Last_Name, Email, [Password], Phone, [Address])
VALUES (@Id_Card, @Name,@Last_Name,@Email,@Password,@Phone,@Address)
END
GO
------
ALTER TABLE [dbo].[Student] ADD CONSTRAINT S_UniqueIdCard UNIQUE(Id_Card)
GO

------------------------
CREATE PROCEDURE ReadStudents
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Card], [Name], [Last_Name], [Email], [Phone]
	FROM [dbo].[Student]
	WHERE Approval = 'en espera';
END

---------------------------

CREATE PROCEDURE ReadStudents
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Card], [Name], [Last_Name], [Email], [Phone]
	FROM [dbo].[Student]
	WHERE Approval = 'en espera';
END

----------------------------------------------------

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
END
----------------------------------------------------
ALTER TABLE [dbo].[Student] DROP CONSTRAINT S_DefaultState;
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT S_DefaultState  DEFAULT ('En Espera') FOR Approval
GO
----------------------------------------------------
--En Espera
--Rehazado
--Aceptado

----------------------------------------------------
UPDATE [dbo].[Student] SET Approval ='En Espera'
WHERE Approval ='en espera'
GO

----------------------------------------------------


ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [P_DefaultActivity]  DEFAULT ('1') FOR [Activity]
GO


ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [CK__Professor__Email__5EBF139D] CHECK  (([Email] like '%@gmail.com'))
GO

ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [P_DefaultRol]  DEFAULT ('Profesor') FOR [Rol]
GO

ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [PR_CreationDateRrofessor]  DEFAULT (getdate()) FOR [Creation_Date]
GO

ALTER TABLE [dbo].[Administrator] ADD  CONSTRAINT [AD_CreationDateADMINISTRATOR]  DEFAULT (getdate()) FOR [Creation_Date]
GO

ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [Co_DefaultCreation]  DEFAULT ('Administrador') FOR [Creation_User]
GO





