IF OBJECT_ID('MTE.GetChecklistShareData', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetChecklistShareData];  
GO

CREATE PROCEDURE [MTE].[GetChecklistShareData]
		@ChecklistId INT,
		@ChecklistName NVARCHAR(100),
		@BookingId INT,
		@UserId INT
AS    
   SET NOCOUNT ON;

   SELECT
		[C].[ShareLink],
		[L].[Name] AS [LocationName],
		[B].[TripDate]
	FROM
		[MTE].[Checklist] [C]
	INNER JOIN
		[MTE].[Booking] [B]
	ON
		[C].[BookingId] = [B].[BookingId]
	INNER JOIN
		[MTE].[Location] [L]
	ON
		[L].[LocationId] = [B].[LocationId]
	INNER JOIN
		[MTE].[User] [U]
	ON
		[U].[UserId] = [B].[UserId]
	WHERE
		[C].[ChecklistId] = @CheckListId
	AND
		LOWER([C].[Name]) = LOWER(@ChecklistName)
	AND
		[U].[UserId] = @UserId
	AND
		[B].[BookingId] = @BookingId
	AND
		[B].[TripDate] >= GETUTCDATE()
   RETURN;
GO 