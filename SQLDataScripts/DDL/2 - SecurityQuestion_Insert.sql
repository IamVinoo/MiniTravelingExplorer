IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'SecurityQuestion'))
BEGIN
    INSERT INTO [MTE].[SecurityQuestion] ([SecurityQuestion], [CreatedDate], [ModifiedDate]) VALUES ('What is your birth date?', GETDATE(), GETDATE());
    INSERT INTO [MTE].[SecurityQuestion] ([SecurityQuestion], [CreatedDate], [ModifiedDate]) VALUES ('What is your first phone number?', GETDATE(), GETDATE());
    INSERT INTO [MTE].[SecurityQuestion] ([SecurityQuestion], [CreatedDate], [ModifiedDate]) VALUES ('What is your first pet name?', GETDATE(), GETDATE());
    INSERT INTO [MTE].[SecurityQuestion] ([SecurityQuestion], [CreatedDate], [ModifiedDate]) VALUES ('What is your first school name?', GETDATE(), GETDATE());
    INSERT INTO [MTE].[SecurityQuestion] ([SecurityQuestion], [CreatedDate], [ModifiedDate]) VALUES ('What is your favorite ice cream flavor?', GETDATE(), GETDATE());
END