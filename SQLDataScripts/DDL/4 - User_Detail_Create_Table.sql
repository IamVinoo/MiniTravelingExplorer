IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'UserDetail'))
BEGIN
    DROP TABLE [MTE].[UserDetail];
END

CREATE TABLE [MTE].[UserDetail] (
    [UserDetailId] INT PRIMARY KEY IDENTITY(1, 1),
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_UserDetail_UserId_User_UserId] FOREIGN KEY (UserId) REFERENCES [MTE].[User](UserId),
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [DateOfBirth] DATE NOT NULL,
    [Email] NVARCHAR(100) UNIQUE NOT NULL,
    [Phone] NVARCHAR(20) NOT NULL,
    [SecurityQuestionId] INT NOT NULL,
    CONSTRAINT [FK_User_SecurityQuestionId_SecurityQuestion_SecurityQuestionId] FOREIGN KEY (SecurityQuestionId) REFERENCES [MTE].[SecurityQuestion](SecurityQuestionId),
    [SecurityAnswer] NVARCHAR(50) NOT NULL,
    [Gender] NVARCHAR(10) NOT NULL,
	[UserPhoto] VARBINARY(MAX),
	[UserPhotoName] NVARCHAR(100),
	[UserPhotoType] NVARCHAR(100),
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);