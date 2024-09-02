IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Room'))
BEGIN
    DROP TABLE [MTE].[Room];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Location'))
BEGIN
    DROP TABLE [MTE].[Location];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Currency'))
BEGIN
    DROP TABLE [MTE].[Currency];
END

CREATE TABLE [MTE].[Currency] (
    [CurrencyId] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,
	[Abbreviation] NVARCHAR(50) NOT NULL,
    [Symbol] NVARCHAR(2) NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);