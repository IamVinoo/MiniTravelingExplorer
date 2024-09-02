IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Testimonial'))
BEGIN
    DROP TABLE [MTE].[Testimonial];
END

CREATE TABLE [MTE].[Testimonial] (
    [TestimonialId] INT PRIMARY KEY IDENTITY(1, 1),
    [ClientName] NVARCHAR(50) NOT NULL,
    [ClientProfession] NVARCHAR(100) NOT NULL,
    [Review] NVARCHAR(4000) NOT NULL,
    [ClientPhotoUrl] NVARCHAR(500) NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);