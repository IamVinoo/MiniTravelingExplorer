IF OBJECT_ID('MTE.InsertUpdateUser', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[InsertUpdateUser];  
GO

CREATE PROCEDURE [MTE].[InsertUpdateUser]
	@UserId INT,
	@SaltKey NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@FullName NVARCHAR(100),
	@Password NVARCHAR(200),
	@DateOfBirth DATE,
	@Email NVARCHAR(100),
	@Phone NVARCHAR(20),
	@SecurityQuestionId INT,
	@SecurityAnswer NVARCHAR(50),
	@Gender NVARCHAR(10),
	@UserPhoto VARBINARY(MAX) NULL,
	@UserPhotoName NVARCHAR(100) NULL,
	@UserPhotoType NVARCHAR(100) NULL,
	@ActivationKey NVARCHAR(50) NULL
AS
	IF (@UserId > 0)
	BEGIN
		UPDATE
			[MTE].[UserDetail]
		SET
			[FirstName] = @FirstName,
			[LastName] = @LastName,
			[FullName] = @FullName,
			[DateOfBirth] = @DateOfBirth,
			[Phone] = @Phone,
			[SecurityQuestionId] = @SecurityQuestionId,
			[SecurityAnswer] = @SecurityAnswer,
			[Gender] = @Gender,
			[UserPhoto] = @UserPhoto,
			[UserPhotoName] = @UserPhotoName,
			[UserPhotoType] = @UserPhotoType,
			[ModifiedDate] = GETUTCDATE()
		WHERE
			[UserId] = @UserId
	END
	ELSE
	BEGIN
		DECLARE @NewUser TABLE (UserId INT);

		INSERT INTO
			[MTE].[User] (
			[SaltKey],
			[Password],
			[IsActivated],
			[ActivationKey],
			[PasswordResetKey],
			[NumberOfAttempt],
			[LockedOutDateTime],
			[ChangeEmailCode],
			[ChangeEmailRequested],
			[ActivatedDate],
			[CreatedDate],
			[ModifiedDate])
		OUTPUT
			INSERTED.UserId
		INTO
			@NewUser
		VALUES (
			@SaltKey,
			@Password,
			0,
			@ActivationKey,
			NULL,
			0,
			NULL,
			NULL,
			NULL,
			NULL,
			GETDATE(),
			GETDATE());

		INSERT INTO
			[MTE].[UserDetail] (
			UserId,
			FirstName,
			LastName,
			FullName,
			DateOfBirth,
			Email,
			Phone,
			SecurityQuestionId,
			SecurityAnswer,
			Gender,
			UserPhoto,
			UserPhotoName,
			UserPhotoType,
			CreatedDate,
			ModifiedDate
			)
		VALUES(
			(SELECT [UserId] FROM @NewUser),
			@FirstName,
			@LastName,
			@FullName,
			@DateOfBirth,
			@Email,
			@Phone,
			@SecurityQuestionId,
			@SecurityAnswer,
			@Gender,
			@UserPhoto,
			@UserPhotoName,
			@UserPhotoType,
			GETUTCDATE(),
			GETUTCDATE());
	END
GO