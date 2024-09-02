IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Currency'))
BEGIN
    INSERT INTO [MTE].[Currency] ([Name], [Abbreviation], [Symbol], [CreatedDate], [ModifiedDate]) VALUES ('US Dollar', 'USD', '$', GETUTCDATE(), GETUTCDATE());
    INSERT INTO [MTE].[Currency] ([Name], [Abbreviation], [Symbol], [CreatedDate], [ModifiedDate]) VALUES ('Canadian Dollar', 'CAD', '$', GETUTCDATE(), GETUTCDATE());
    INSERT INTO [MTE].[Currency] ([Name], [Abbreviation], [Symbol], [CreatedDate], [ModifiedDate]) VALUES ('Euro', 'EUR', '€', GETUTCDATE(), GETUTCDATE());
    INSERT INTO [MTE].[Currency] ([Name], [Abbreviation], [Symbol], [CreatedDate], [ModifiedDate]) VALUES ('Pound', 'GBP', '£', GETUTCDATE(), GETUTCDATE());
END