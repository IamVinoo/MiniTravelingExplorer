IF OBJECT_ID('MTE.DeleteChecklist', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[DeleteChecklist];  
GO

CREATE PROCEDURE [MTE].[DeleteChecklist]
	@CheckListId INT,
	@BookingId INT,
	@UserId INT
AS
	DECLARE @isValidChecklist BIT;
	SELECT @isValidChecklist = (SELECT
									TOP 1 1
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
								WHERE
									[U].[UserId] = @UserId
								AND
									[C].[ChecklistId] = @CheckListId
								AND
									[B].[BookingId] = @BookingId
								AND
									[B].[TripDate] >= GETUTCDATE());

	IF (@isValidChecklist = 1)
	BEGIN
		DELETE FROM
			[MTE].[ChecklistItem]
		WHERE
			[ChecklistId] = @CheckListId;

		DELETE FROM
			[MTE].[Checklist]
		WHERE
			[ChecklistId] = @CheckListId;
	END
	RETURN;
GO 