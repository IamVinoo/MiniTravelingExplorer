IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'User'))
BEGIN
    INSERT INTO [MTE].[User] ([SaltKey], [Password], [IsActivated], [ActivationKey], [PasswordResetKey], [NumberOfAttempt], [LockedOutDateTime], [ChangeEmailCode], [ChangeEmailRequested], [ActivatedDate], [IsAdmin], [CreatedDate], [ModifiedDate]) VALUES ('M0BztAOzgNbhAwd0qMncgA==', 'ADN4fKmRJoV/wlT29Jdbl2naXM9Bm13j2s3/yA9ZyE5GPUfpJ1/pPq2roQQ84tblOQ==', 1, NULL, NULL, 0, NULL, NULL, NULL, NULL, 1, GETDATE(), GETDATE());
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'UserDetail'))
BEGIN
    INSERT INTO [MTE].[UserDetail] ([UserId], [FirstName], [LastName], [FullName], [DateOfBirth], [Email], [Phone], [SecurityQuestionId], [SecurityAnswer], [Gender], [CreatedDate], [ModifiedDate]) VALUES (1, 'Admin', 'User', 'Admin User', GETDATE(), 'adminuser@gmail.com', '(123) 456-7890', 3, 'Pet', 'Male', GETDATE(), GETDATE());
END