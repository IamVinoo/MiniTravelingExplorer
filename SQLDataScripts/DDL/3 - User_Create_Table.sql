IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'ChecklistItem'))
BEGIN
	DROP TABLE [MTE].[ChecklistItem]
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Checklist'))
BEGIN
    DROP TABLE [MTE].[Checklist];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Booking'))
BEGIN
    DROP TABLE [MTE].[Booking];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'UserDetail'))
BEGIN
    DROP TABLE [MTE].[UserDetail];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'User'))
BEGIN
    DROP TABLE [MTE].[User];
END

CREATE TABLE [MTE].[User] (
    [UserId] INT PRIMARY KEY IDENTITY(1, 1),
	[SaltKey] NVARCHAR(50),
    [Password] NVARCHAR(200) NOT NULL,
    [IsActivated] BIT NOT NULL DEFAULT 0,
	[ActivationKey] NVARCHAR(50),
	[PasswordResetKey] NVARCHAR(50),
    [NumberOfAttempt] INT NOT NULL DEFAULT 0,
    [LockedOutDateTime] DATETIME,
	[ChangeEmailCode] INT,
	[ChangeEmailRequested] NVARCHAR(100),
    [ActivatedDate] DATETIME,
	[IsAdmin] BIT NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);