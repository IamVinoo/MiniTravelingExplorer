IF OBJECT_ID('MTE.UpdateLoginUser', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[UpdateLoginUser];  
GO

CREATE PROCEDURE [MTE].[UpdateLoginUser]
	@FullName NVARCHAR(100),
	@Email NVARCHAR(100),
	@Password NVARCHAR(200),
	@ActivationKey NVARCHAR(50),
	@PasswordResetKey NVARCHAR(50),
	@IsActivate BIT
AS
	DECLARE @isActivated INT;
	DECLARE @selectedResetPasswordKey NVARCHAR(50);
	DECLARE @selectedActivationKey NVARCHAR(50);
	DECLARE @selectedPassword NVARCHAR(200);

	IF (@IsActivate != 1)
	BEGIN
		SELECT
			@isActivated = [U].[IsActivated],
			@selectedActivationKey = [U].[ActivationKey],
			@selectedPassword = [U].[Password]
		FROM
			[MTE].[User] [U]
		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[UD].[Email] = @Email

		IF (@Password IS NULL OR @Password = '')
		BEGIN
			SET @selectedResetPasswordKey = @PasswordResetKey;
		END
		ELSE
		BEGIN
			SET @selectedResetPasswordKey = NULL;
			SET @selectedPassword = @Password;
		END
	END
	ELSE
	BEGIN
		SET @isActivated = 1;
		SET @selectedActivationKey = NULL;

		SELECT
			@selectedResetPasswordKey = [U].[PasswordResetKey],
			@selectedPassword = [U].[Password]
		FROM
			[MTE].[User] [U]
		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[UD].[Email] = @Email
	END

	UPDATE
		[U]
	SET
		[U].[IsActivated] = @isActivated,
		[U].[ActivationKey] = @SelectedActivationKey,
		[U].[Password] = @selectedPassword,
		[U].[PasswordResetKey] = @selectedResetPasswordKey,
		[U].[ModifiedDate] = GETUTCDATE()
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[UD].[Email] = @Email
	AND (
		CASE
			WHEN
				@IsActivate = 1 THEN
				CASE
					WHEN [UD].[FullName] = @FullName THEN  1
					ELSE 0
				END
			ELSE 1
		END) = 1
	AND (
		CASE
			WHEN
				@IsActivate = 1 THEN
				CASE
					WHEN [U].[ActivationKey] = @ActivationKey THEN  1
					ELSE 0
				END
			ELSE 1
		END) = 1
	AND (
		CASE
			WHEN
				(@IsActivate = 0 AND @Password IS NOT NULL AND @Password != '') THEN
				CASE
					WHEN [U].[PasswordResetKey] = @PasswordResetKey THEN  1
					ELSE 0
				END
			ELSE 1
		END) = 1
GO