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

CREATE TABLE [MTE].[Booking] (
    [BookingId] INT PRIMARY KEY IDENTITY(1, 1),
    [LocationId] INT NOT NULL,
	CONSTRAINT [FK_Booking_LocationId_Location_LocationId] FOREIGN KEY (LocationId) REFERENCES [MTE].[Location](LocationId),
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_Booking_UserId_User_UserId] FOREIGN KEY (UserId) REFERENCES [MTE].[User](UserId),
	[BookingEmail] NVARCHAR(100) NOT NULL,
	[TicketNumber] NVARCHAR(100) NOT NULL,
	[NumberOfTicket] INT NOT NULL,
	[Amount] FLOAT NOT NULL,
    [CurrencyId] INT NOT NULL DEFAULT 1,
    CONSTRAINT [FK_Booking_CurrencyId_Currency_CurrencyId] FOREIGN KEY (CurrencyId) REFERENCES [MTE].[Currency](CurrencyId),
	[CardNumber] NVARCHAR(20) NOT NULL,
	[CardName] NVARCHAR(50) NOT NULL,
	[TransactionNumber] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[TripDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);