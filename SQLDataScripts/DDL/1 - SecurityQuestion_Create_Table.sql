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
				 AND [TABLE_NAME] = 'SecurityQuestion'))
BEGIN
    DROP TABLE [MTE].[SecurityQuestion];
END

CREATE TABLE [MTE].[SecurityQuestion] (
    [SecurityQuestionId] INT PRIMARY KEY IDENTITY(1, 1),
    [SecurityQuestion] NVARCHAR(200) NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETDATE()
);