IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'UserIpInfo'))
BEGIN
	DROP TABLE [MTE].[UserIpInfo]
END

CREATE TABLE [MTE].[UserIpInfo] (
    [UserIpInfoId] INT PRIMARY KEY IDENTITY(1, 1),
	[Ip] NVARCHAR(100),
	[User] NVARCHAR(100),
	[BrowserType] NVARCHAR(100),
	[BrowserName] NVARCHAR(200),
	[BrowserVersion] NVARCHAR(50),
	[IsMobileDevice] Bit,
	[Platform] NVARCHAR(100),
	[Version] NVARCHAR(50),
	[City] NVARCHAR(100),
	[Region] NVARCHAR(100),
	[Country] NVARCHAR(100),
	[TimeZone] NVARCHAR(100),
	[HostName] NVARCHAR(200),
	[Organization] NVARCHAR(200),
	[IsAdminUser] BIT,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
);