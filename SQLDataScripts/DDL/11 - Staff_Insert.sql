IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Staff'))
BEGIN
    INSERT INTO [MTE].[Staff] ([Name], [Designation], [LinkedInUrl], [FacebookUrl], [InstagramUrl], [StaffImage], [StaffImageType], [CreatedDate], [ModifiedDate]) VALUES ('Test Developer 1', 'Software Developer', 'https://www.linkedin.com/in/TestDeveloper1/', 'https://www.facebook.com/TestDeveloper1', 'https://www.instagram.com/TestDeveloper1/', 0x, 'data:image/jpeg;base64,', GETUTCDATE(), GETUTCDATE());
END