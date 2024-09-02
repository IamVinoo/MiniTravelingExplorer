IF OBJECT_ID('MTE.UpdateUserEmail', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[UpdateUserEmail]
GO

CREATE PROCEDURE [MTE].[UpdateUserEmail]
	@UserId INT,
	@Email NVARCHAR(100),
	@ChangeEmailCode INT,
	@ChangeEmailRequested NVARCHAR(100),
	@IsUpdateEmail BIT
AS
	IF(@IsUpdateEmail = 1)
	BEGIN
		UPDATE
			[UD]
		SET
			[UD].[Email] = @ChangeEmailRequested,
			[UD].[ModifiedDate] = GETUTCDATE()
		FROM
			[MTE].[UserDetail] [UD]
		INNER JOIN
			[MTE].[User] [U]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[UD].[UserId] = @UserId
		AND
			[U].[ChangeEmailCode] = @ChangeEmailCode
		AND
			[U].[ChangeEmailRequested] = @ChangeEmailRequested
		AND
			[UD].[Email] = @Email;

		UPDATE
			[U]
		SET
			[U].[ChangeEmailCode] = NULL,
			[U].[ChangeEmailRequested] = NULL,
			[U].[ModifiedDate] = GETUTCDATE()
		FROM
			[MTE].[User] [U]
		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[U].[UserId] = @UserId
		AND
			[U].[ChangeEmailCode] = @ChangeEmailCode
		AND
			[U].[ChangeEmailRequested] = @ChangeEmailRequested
		AND
			[UD].[Email] = @Email;
	END
	ELSE
	BEGIN
		UPDATE
			[U]
		SET
			[U].[ChangeEmailCode] = @ChangeEmailCode,
			[U].[ChangeEmailRequested] = @ChangeEmailRequested,
			[U].[ModifiedDate] = GETUTCDATE()
		FROM
			[MTE].[User] [U]
		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[U].[UserId] = @UserId
		AND [UD].[Email] = [Email]
	END
GO 