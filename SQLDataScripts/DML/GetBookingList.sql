IF OBJECT_ID('MTE.GetBookingList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetBookingList];  
GO

CREATE PROCEDURE [MTE].[GetBookingList]
	@UserId INT
AS    
   SET NOCOUNT ON;

	SELECT
		[B].[BookingId],
		[B].[TicketNumber],
		[L].[Name] AS [LocationName],
		[B].[NumberOfTicket],
		[B].[TripDate],
		CONCAT([C].[Symbol], ROUND(CAST([B].[Amount] AS DECIMAL(18,2)), 2)) AS [Amount],
		[UD].[FullName] AS [BookedBy],
		[B].[BookingEmail],
		CASE
		WHEN
			[B].[TripDate] >= GETUTCDATE()
		THEN
			1
		ELSE
			0
		END AS [TripStatus]
	FROM
		[MTE].[Booking] [B]
	INNER JOIN
		[MTE].[Location] [L]
	ON
		[B].[LocationId] = [L].[LocationId]
	INNER JOIN
		[MTE].[User] [U]
	ON
		[B].[UserId] = [U].[UserId]
	INNER JOIN
		[MTE].[UserDetail] [UD]
	ON
		[U].[UserId] = [UD].[UserId]
	INNER JOIN
		[MTE].[Currency] [C]
	ON
		[B].[CurrencyId] = [C].[CurrencyId]
	WHERE
		[B].[UserId] = @UserId
   RETURN;
GO 