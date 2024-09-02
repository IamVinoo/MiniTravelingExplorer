IF OBJECT_ID('MTE.GetUserByEmail', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserByEmail];  
GO

CREATE PROCEDURE [MTE].[GetUserByEmail]
	@Email NVARCHAR(100),
	@Password NVARCHAR(200) OUTPUT,
	@NoOfAttempt INT OUTPUT,
	@LockedOutDateTime DATETIME OUTPUT
AS    
	SET NOCOUNT ON;
	DECLARE @attemptNumber INT;
	
	SELECT
		@Password = [U].[Password],
		@attemptNumber = [U].[NumberOfAttempt],
		@LockedOutDateTime = [U].[LockedOutDateTime]
	FROM
		[MTE].[USER] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[UD].[Email] = @Email
	AND
		[U].[IsAdmin] != 1;

	SELECT @NoOfAttempt = @attemptNumber + 1;

	UPDATE
		[U]
	SET
		[U].[NumberOfAttempt] = @NoOfAttempt,
		[U].[LockedOutDateTime] = CASE
									WHEN @NoOfAttempt = 3
										THEN GETUTCDATE()
									ELSE
										[U].[LockedOutDateTime]
								  END
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[UD].[Email] = @Email
	AND
		[U].[IsAdmin] != 1;

	SELECT
		[UD].[UserId],
		[UD].[FullName],
		[UD].[Email],
		[UD].[UserPhoto],
		[UD].[UserPhotoName],
		[UD].[UserPhotoType],
		[U].[IsActivated],
		[U].[NumberOfAttempt],
		[U].[LockedOutDateTime],
		[U].[IsActivated]
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[Email] = @Email
	AND
		[Password] = @Password
	AND
		[U].[IsAdmin] != 1;

   RETURN;
GO 