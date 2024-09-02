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

CREATE TABLE [MTE].[Checklist] (
    [ChecklistId] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL,
    [BookingId] INT NOT NULL,
    CONSTRAINT [FK_Checklist_BookingId_Booking_BookingId] FOREIGN KEY (BookingId) REFERENCES [MTE].[Booking](BookingId),
	[ShareLink] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);