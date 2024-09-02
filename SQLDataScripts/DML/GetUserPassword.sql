IF OBJECT_ID('MTE.GetUserPassword', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserPassword]
GO

CREATE PROCEDURE [MTE].[GetUserPassword]
	@UserId INT,
	@Email NVARCHAR(100),
	@FullName NVARCHAR(100),
	@IsUpdatePassword BIT,
	@IsVerifyAdmin BIT = 0
AS
	SELECT
		[U].[UserId],
		[UD].[FullName],
		[UD].[Email],
		[UD].[UserPhoto],
		[UD].[UserPhotoName],
		[UD].[UserPhotoType],
		[SaltKey],
		[Password]
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserID]
	WHERE
		[UD].[Email] = @Email
	AND (
		CASE
			WHEN
				(@IsUpdatePassword = 1) THEN
				CASE
					WHEN
						[U].[UserId] = @UserId
						AND [UD].[FullName] = @FullName THEN 1
					ELSE 0
				END
			ELSE 1
		END) = 1
	AND (
		CASE
			WHEN
				(@IsVerifyAdmin = 1) THEN
				CASE
					WHEN
						[U].[IsAdmin] = 1
					AND
						[U].[IsActivated] = 1 THEN 1
					ELSE 0
				END
			ELSE 1
		END) = 1
GO 