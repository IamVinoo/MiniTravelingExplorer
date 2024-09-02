IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Subscriber'))
BEGIN
    DROP TABLE [MTE].[Subscriber];
END

IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Promotion'))
BEGIN
    DROP TABLE [MTE].[Promotion];
END

CREATE TABLE [MTE].[Promotion] (
    [PromotionId] INT PRIMARY KEY IDENTITY(1, 1),
	[PromotionName] NVARCHAR(50) NOT NULL,
	[PromotionValue] INT NOT NULL,
	[IsPercent] BIT NOT NULL DEFAULT 0,
	[IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);