IF OBJECT_ID('MTE.UpdateUserPassword', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[UpdateUserPassword]
GO

CREATE PROCEDURE [MTE].[UpdateUserPassword]
	@UserId INT,
	@Email NVARCHAR(100),
	@Password NVARCHAR(200)
AS
	UPDATE
		[U]
	SET
		[Password] = @Password,
		[ModifiedDate] = GETUTCDATE()
	FROM
		[MTE].[User] [U]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	WHERE
		[U].[UserId] = @UserId
	AND
		[UD].[Email] = @Email;
GO 