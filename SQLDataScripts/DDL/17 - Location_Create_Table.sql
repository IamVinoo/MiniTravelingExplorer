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
	DROP TABLE [MTE].[Booking]
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Location'))
BEGIN
    DROP TABLE [MTE].[Location];
END

CREATE TABLE [MTE].[Location] (
    [LocationId] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL,
    [Activity] NVARCHAR(100) NOT NULL,
    [CurrencyId] INT NOT NULL,
    CONSTRAINT [FK_Location_CurrencyId_Currency_CurrencyId] FOREIGN KEY (CurrencyId) REFERENCES [MTE].[Currency](CurrencyId),
	[Rate] INT NOT NULL,
	[TotalNumberOfPerson] NVARCHAR(50),
	[Ticket] INT NOT NULL,
    [Description] NVARCHAR(2000) NOT NULL,
	[OpeningTime] TIME NOT NULL,
	[ClosingTime] TIME NOT NULL,
    [LocationImageUrl] NVARCHAR(2000) NOT NULL,
    [Lattitude] NVARCHAR(500) NOT NULL,
    [Longitude] NVARCHAR(500) NOT NULL,
    [IsOffice] BIT NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);