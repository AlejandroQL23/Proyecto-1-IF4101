--RESTRICCIONES PARA ALDIFA MVC
USE ALDIFA_SOFT_MVC_IF4101;
GO

ALTER TABLE [dbo].[ProfessorConsultation] ADD  CONSTRAINT [US_CreationUser]  DEFAULT 'Estudiante' FOR [CreationUser]
GO

UPDATE [dbo].[ProfessorConsultation] SET [CreationUser] = 'Estudiante'
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [US_CreationUserForUser]  DEFAULT 'Administrador' FOR [CreationUser]
GO

ALTER TABLE [dbo].[ForumCommentAnswer] ADD  CONSTRAINT [US_CreationUserForForumCommentAnswer]  DEFAULT 'Estudiante' FOR [CreationUser]
GO

ALTER TABLE [dbo].[ForumComment] ADD  CONSTRAINT [US_CreationUserForForumComment]  DEFAULT 'Estudiante' FOR [CreationUser]
GO


ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [US_CreationUserForGroup]  DEFAULT 'Administrador' FOR [CreationUser]
GO

ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [US_CreationUserForCourse]  DEFAULT 'Administrador' FOR [CreationUser]
GO


ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [CO_CreationDateCourse]  DEFAULT (getdate()) FOR [CreationDate]
GO





--RESTRICCIONES PARA ALDIFA API
USE ALDIFA_SOFT_API_IF4101;
GO


ALTER TABLE [dbo].[News] ADD  CONSTRAINT [US_CreationUserForNews]  DEFAULT 'Administrador' FOR [CreationUser]
GO

ALTER TABLE [dbo].[NewsComment] ADD  CONSTRAINT [US_CreationUserForNewsComment]  DEFAULT ('Usuario E-P') FOR [CreationUser]
GO







