IF OBJECT_ID('MTE.GetRoomList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetRoomList];  
GO

CREATE PROCEDURE [MTE].[GetRoomList]
	@IsFeatured BIT = 0
AS    
   SET NOCOUNT ON;

   SELECT
		[R].[RoomId],
		[R].[Name],
		[R].[Rating],
		[R].[Rate],
		[C].[Symbol] AS [CurrencySymbol],
		[R].[PerDayOrNight],
		[R].[BedNumber],
		[R].[BathNumber],
		[R].[HasWifi],
		[R].[Description],
		[R].[IsFeatured],
		[R].[RoomImageUrl]
	FROM
		[MTE].[Room] [R]
	INNER JOIN
		[MTE].[Currency] [C]
	ON
		[R].[CurrencyId] = [C].[CurrencyId]
	WHERE
		(@IsFeatured = 0 OR [R].[IsFeatured] = @IsFeatured);
   RETURN;
GO 