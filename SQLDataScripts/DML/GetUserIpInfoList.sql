IF OBJECT_ID('MTE.GetUserIpInfoList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetUserIpInfoList];  
GO

CREATE PROCEDURE [MTE].[GetUserIpInfoList]
	@UserId INT
AS    
   SET NOCOUNT ON;

   DECLARE @IsAdminUser BIT = (SELECT [IsAdmin] FROM [MTE].[User] WHERE [UserId] = @UserId);

   IF (@IsAdminUser = 1)
   BEGIN
	   SELECT
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
			[CreatedDate]
		FROM
			[MTE].[UserIpInfo]
		ORDER BY
			[CreatedDate] DESC;
   END
   RETURN;
GO 