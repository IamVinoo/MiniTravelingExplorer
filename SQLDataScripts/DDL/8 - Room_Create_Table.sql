IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Room'))
BEGIN
    DROP TABLE [MTE].[Room];
END

CREATE TABLE [MTE].[Room] (
    [RoomId] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,
    [Rating] FLOAT NOT NULL,
	[Rate] INT NOT NULL,
    [CurrencyId] INT NOT NULL,
    CONSTRAINT [FK_Room_CurrencyId_Currency_CurrencyId] FOREIGN KEY (CurrencyId) REFERENCES [MTE].[Currency](CurrencyId),
	[PerDayOrNight] NVARCHAR(50),
    [BedNumber] INT NOT NULL DEFAULT 0,
    [BathNumber] INT NOT NULL DEFAULT 0,
    [HasWifi] BIT NOT NULL DEFAULT 0,
    [Description] NVARCHAR(200) NOT NULL,
    [IsFeatured] BIT NOT NULL DEFAULT 0,
	[RoomImageUrl] NVARCHAR(MAX) NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);