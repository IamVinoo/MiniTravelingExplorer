IF OBJECT_ID('MTE.InsertUserDetailByIp', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[InsertUserDetailByIp];  
GO

CREATE PROCEDURE [MTE].[InsertUserDetailByIp]
	@Ip NVARCHAR(100),
	@User NVARCHAR(100),
	@BrowserType NVARCHAR(100),
	@BrowserName NVARCHAR(200),
	@BrowserVersion NVARCHAR(50),
	@IsMobileDevice BIT,
	@Platform NVARCHAR(100),
	@Version NVARCHAR(50),
	@City NVARCHAR(100),
	@Region NVARCHAR(100),
	@Country NVARCHAR(100),
	@TimeZone NVARCHAR(100),
	@HostName NVARCHAR(200),
	@Organization NVARCHAR(200),
	@IsAdminUser BIT
AS
	IF NOT EXISTS (
		SELECT 1
		FROM (
			SELECT TOP 10 *
			FROM [MTE].[UserIpInfo]
			ORDER BY [UserIpInfoId] DESC
		) AS LastTenRows
		WHERE [Ip] = @Ip
		  AND [BrowserName] = @BrowserName
		  AND [BrowserVersion] = @BrowserVersion
		  AND [IsMobileDevice] = @IsMobileDevice
		  AND [IsAdminUser] = @IsAdminUser)
	BEGIN
		INSERT INTO
			[MTE].[UserIpInfo] (
			[Ip],
			[User],
			[BrowserType],
			[BrowserName],
			[BrowserVersion],
			[IsMobileDevice],
			[Platform],
			[Version],
			[City],
			[Region],
			[Country],
			[TimeZone],
			[HostName],
			[Organization],
			[IsAdminUser],
			[CreatedDate],
			[ModifiedDate])
		VALUES (
			@Ip,
			@User,
			@BrowserType,
			@BrowserName,
			@BrowserVersion,
			@IsMobileDevice,
			@Platform,
			@Version,
			@City,
			@Region,
			@Country,
			@TimeZone,
			@HostName,
			@Organization,
			@IsAdminUser,
			GETDATE(),
			GETDATE());
	END
GO