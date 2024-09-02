IF OBJECT_ID('MTE.GetUserLockOutInfo', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserLockOutInfo];  
GO

CREATE PROCEDURE [MTE].[GetUserLockOutInfo]
	@Email NVARCHAR(100),
	@IsValidPassword BIT,
	@IsValidateLockOutTime BIT,
	@LockedOutDateTime DATETIME OUT
AS    
	SET NOCOUNT ON;
   
	IF (@IsValidateLockOutTime = 1)
	BEGIN
		DECLARE @NumberOfAttempt INT = 0;
		SELECT @LockedOutDateTime = NULL;

		IF (@IsValidPassword = 0)
		BEGIN
			SELECT @NumberOfAttempt = (SELECT
											[U].[NumberOfAttempt]
										FROM
											[MTE].[User] [U]
										INNER JOIN
											[MTE].[UserDetail] [UD]
										ON
											[U].[UserId] = [UD].[UserId]
										WHERE
											[UD].[Email] = @Email);
			SELECT @LockedOutDateTime = GETUTCDATE();
		END

		UPDATE
			[U]
		SET
			[NumberOfAttempt] = @NumberOfAttempt,
			[LockedOutDateTime] = @LockedOutDateTime
		FROM
			[MTE].[User] [U]
		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[UD].[Email] = @Email;
	END

	SELECT
		[U].[NumberOfAttempt],
		[U].[LockedOutDateTime]
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[UD].[Email] = @Email;

	RETURN;
GO 