IF OBJECT_ID('MTE.InsertChecklist', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[InsertChecklist];  
GO

CREATE PROCEDURE [MTE].[InsertChecklist]
	@CheckListName NVARCHAR(100),
	@BookingId INT,
	@ShareLink NVARCHAR(500),
	@UserId INT,
	@IsChecklistNameExists BIT = 0 OUTPUT
AS
	DECLARE @isValidChecklist BIT = (SELECT
										TOP 1 1
									 FROM
									 	[MTE].[Booking] [B]
									 INNER JOIN
									 	[MTE].[User] [U]
									 ON
									 	[U].[UserId] = [B].[UserId]
									 WHERE
									 	[U].[UserId] = @UserId
									 AND
									 	[B].[BookingId] = @BookingId
									 AND
									 	[B].[TripDate] >= GETUTCDATE());	

	IF (@isValidChecklist = 1)
	BEGIN
		DECLARE @isValidChecklistName BIT = (SELECT
											TOP 1 1
										 FROM
										 	[MTE].[Checklist] [C]
										 INNER JOIN
										 	[MTE].[Booking] [B]
										 ON
										 	[B].[BookingId] = [C].[BookingId]
										 WHERE
										 	LOWER([C].[Name]) = LOWER(@CheckListName)
										 AND
										 	[B].[TripDate] >= GETUTCDATE());

		SET @IsChecklistNameExists = ISNULL(@isValidChecklistName, 0);

		IF (@IsChecklistNameExists = 0)
		BEGIN
			INSERT INTO
				[MTE].[Checklist] (
				[Name],
				[BookingId],
				[ShareLink])
			VALUES (
				@CheckListName,
				@BookingId,
				@ShareLink
			);
		END
	END

	RETURN;
GO 