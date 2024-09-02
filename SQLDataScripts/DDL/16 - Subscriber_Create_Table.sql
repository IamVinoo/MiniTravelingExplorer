IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Subscriber'))
BEGIN
    DROP TABLE [MTE].[Subscriber];
END

CREATE TABLE [MTE].[Subscriber] (
    [SubscriberId] INT PRIMARY KEY IDENTITY(1, 1),
    [Email] NVARCHAR(100) UNIQUE NOT NULL,
	[PromoCode] NVARCHAR(20) NOT NULL,
	[PromotionId] INT NOT NULL FOREIGN KEY REFERENCES [MTE].[Promotion]([PromotionId]),
    CONSTRAINT [FK_Subscriber_PromotionId_Promotion_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [MTE].[Promotion]([PromotionId]),
	[IsActive] BIT NOT NULL DEFAULT 1,
	[IsUnsubscribed] BIT NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);