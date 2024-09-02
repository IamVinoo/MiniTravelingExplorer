IF OBJECT_ID('MTE.DeleteChecklistItem', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[DeleteChecklistItem];  
GO

CREATE PROCEDURE [MTE].[DeleteChecklistItem]
	@ChecklistItemId INT,
	@CheckListId INT,
	@BookingId INT,
	@UserId INT
AS
	DECLARE @isValidChecklistItem BIT;
	SELECT @isValidChecklistItem = (SELECT
									TOP 1 1
								FROM
									[MTE].[ChecklistItem] [CI]
								INNER JOIN
									[MTE].[Checklist] [C]
								ON
									[CI].[ChecklistId] = [C].[ChecklistId]
								INNER JOIN
									[MTE].[Booking] [B]
								ON
									[C].[BookingId] = [B].[BookingId]
								INNER JOIN
									[MTE].[User] [U]
								ON
									[U].[UserId] = [B].[UserId]
								WHERE
									[CI].[ChecklistItemId] = @ChecklistItemId
								AND
									[U].[UserId] = @UserId
								AND
									[C].[ChecklistId] = @CheckListId
								AND
									[B].[BookingId] = @BookingId
								AND
									[B].[TripDate] >= GETUTCDATE());

	IF (@isValidChecklistItem = 1)
	BEGIN
		DELETE FROM
			[MTE].[ChecklistItem]
		WHERE
			[ChecklistItemId] = @CheckListItemId;
	END
	RETURN;
GO 