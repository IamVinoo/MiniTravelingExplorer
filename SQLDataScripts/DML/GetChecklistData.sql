IF OBJECT_ID('MTE.GetChecklistData', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetChecklistData];  
GO

CREATE PROCEDURE [MTE].[GetChecklistData]
	@UserId INT
AS    
	SET NOCOUNT ON;
	
	SELECT
		[C].[ChecklistId],
		[C].[Name] AS [ChecklistName],
		[L].[Name] AS [LocationName],
		[B].[TripDate],
		[B].[BookingId],
		COUNT([CI].[ChecklistItemId]) AS [ChecklistItemCount]
	FROM
		[MTE].[Checklist] [C]
	INNER JOIN
		[MTE].[Booking] [B]
	ON
		[C].[BookingId] = [B].[BookingId]
	INNER JOIN
		[MTE].[User] [U]
	ON
		[U].[UserId] = [B].[UserId]
	INNER JOIN
		[MTE].[Location] [L]
	ON
		[B].[LocationId] = [L].[LocationId]
	LEFT JOIN
		[MTE].[ChecklistItem] [CI]
	ON
		[CI].[ChecklistId] = [C].[ChecklistId]
	WHERE
		[U].[UserId] = @UserId
	AND
		[B].[TripDate] >= GETUTCDATE()
	GROUP BY
        [C].[ChecklistId], [C].[Name], [L].[Name], [B].[TripDate], [B].[BookingId];
	
	SELECT
		[B].[BookingId],
		[L].[Name] + ' - ' + [B].[TicketNumber] AS [BookingName]
	FROM
		[MTE].[Booking] [B]
	INNER JOIN
		[MTE].[Location] [L]
	ON  [B].[LocationId] = [L].[LocationId]
	WHERE
		[UserId] = @UserId
	AND
		[TripDate] >= GETUTCDATE();
	
	RETURN;
GO 