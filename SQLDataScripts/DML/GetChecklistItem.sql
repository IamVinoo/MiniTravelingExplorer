IF OBJECT_ID('MTE.GetChecklistItem', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetChecklistItem];  
GO

CREATE PROCEDURE [MTE].[GetChecklistItem]
	@CheckListId INT,
	@BookingId INT,
	@UserId INT = 0,
	@ShareLink NVARCHAR(500) = ''
AS    
   SET NOCOUNT ON;

   IF (@ShareLink = '' OR @ShareLink IS NULL)
   BEGIN
	   SELECT
			[CI].[ChecklistItemId],
			[CI].[Name],
			[CI].[IsChecked]
		FROM
			[MTE].[ChecklistItem] [CI]
		INNER JOIN
			[MTE].[Checklist] [C]
		ON [CI].[ChecklistId] = [C].[ChecklistId]
		INNER JOIN
			[MTE].[Booking] [B]
		ON [C].[BookingId] = [B].[BookingId]
		INNER JOIN
			[MTE].[Location] [L]
		ON [B].[LocationId] = [L].[LocationId]
		INNER JOIN
			[MTE].[User] [U]
		ON [U].[UserId] = [B].[UserId]
		WHERE
			[CI].[ChecklistId] = @CheckListId
		AND
			[U].[UserId] = @UserId
		AND
			[B].[BookingId] = @BookingId
		AND
			[B].[TripDate] >= GETUTCDATE();
	END
	ELSE
	BEGIN
		SELECT
			[CI].[ChecklistItemId],
			[CI].[Name],
			[CI].[IsChecked]
		FROM
			[MTE].[ChecklistItem] [CI]
		INNER JOIN
			[MTE].[Checklist] [C]
		ON
			[C].[ChecklistId] = [CI].[ChecklistId]
		INNER JOIN
			[MTE].[Booking] [B]
		ON
			[C].[BookingId] = [B].[BookingId]
		WHERE
			[C].[ShareLink] = @ShareLink
		AND
			[B].[BookingId] = @BookingId
		AND
			[B].[TripDate] >= GETUTCDATE();
	END
   RETURN;
GO 