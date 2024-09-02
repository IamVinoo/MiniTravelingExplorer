IF OBJECT_ID('MTE.GetUserByEmailAndId', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserByEmailAndId];  
GO

CREATE PROCEDURE [MTE].[GetUserByEmailAndId]
	@UserId INT,
	@Email NVARCHAR(100)
AS    
   SET NOCOUNT ON;

   SELECT
		[FirstName],
		[LastName],
		[DateOfBirth],
		[Phone],
		[SecurityQuestionId],
		[SecurityAnswer],
		[Gender],
		[UserPhoto],
		[UserPhotoName],
		[UserPhotoType]
	FROM
		[MTE].[UserDetail]
	WHERE
		[Email] = @Email
		AND [UserId] = @UserId;
   
   RETURN;
GO 