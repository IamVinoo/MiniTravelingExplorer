IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Promotion'))
BEGIN
    INSERT INTO [MTE].[Promotion] ([PromotionName], [PromotionValue], [IsPercent], [IsActive]) VALUES ('EmailSubscription', '20', 0, 1);
END