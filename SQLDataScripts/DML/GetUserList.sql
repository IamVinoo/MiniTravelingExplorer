IF OBJECT_ID('MTE.GetUserList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserList];  
GO

CREATE PROCEDURE [MTE].[GetUserList]
	@UserId INT,
	@IsAdmin BIT
AS    
   SET NOCOUNT ON;

   DECLARE @IsAdminUser BIT = (SELECT [IsAdmin] FROM [MTE].[User] WHERE [UserId] = @UserId);

   IF (@IsAdminUser = 1)
   BEGIN
	   SELECT
			[U].[UserId],
			[UD].[FullName],
			[UD].[DateofBirth],
			[UD].[Email],
			[UD].[Phone],
			[UD].[Gender],
			[UD].[UserPhoto],
			[UD].[UserPhotoType],
			[UD].[UserPhotoName],
			[U].[IsActivated]
		FROM
			[MTE].[UserDetail] [UD]
		INNER JOIN
			[MTE].[User] [U]
		ON
			[UD].[UserId] = [U].[UserId]
		WHERE
			[U].[IsAdmin] = @IsAdmin;
   END
   RETURN;
GO 