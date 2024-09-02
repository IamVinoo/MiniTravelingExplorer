IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'ChecklistItem'))
BEGIN
    DROP TABLE [MTE].[ChecklistItem];
END

CREATE TABLE [MTE].[ChecklistItem] (
    [ChecklistItemId] INT PRIMARY KEY IDENTITY(1, 1),
    [ChecklistId] INT NOT NULL,
    CONSTRAINT [FK_ChecklistItem_ChecklistId_Checklist_ChecklistId] FOREIGN KEY (ChecklistId) REFERENCES [MTE].[Checklist](ChecklistId),
	[Name] NVARCHAR(100) NOT NULL,
	[IsChecked] BIT NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);