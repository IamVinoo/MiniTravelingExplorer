IF OBJECT_ID('MTE.InsertUpdateChecklistItem', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[InsertUpdateChecklistItem];  
GO

CREATE PROCEDURE [MTE].[InsertUpdateChecklistItem]
	@ChecklistId INT,
	@ChecklistItemId INT,
	@ChecklistItemName NVARCHAR(100) = NULL,
	@BookingId INT,
	@UserId INT,
	@IsChecked BIT = 0,
	@IsChecklistItemExists BIT OUTPUT,
	@CreatedChecklistItemId INT = 0 OUTPUT
AS
	DECLARE @isItemExists BIT = (SELECT TOP 1 1
											FROM
												[MTE].[ChecklistItem]
											WHERE
												[CheckListId] = @ChecklistId
											AND
												LOWER([Name]) = LOWER(@ChecklistItemName));

	SELECT @isChecklistItemExists = ISNULL(@isItemExists, 0);
	SELECT @CreatedChecklistItemId = 0;

	IF(@IsChecklistItemExists = 0)
	BEGIN
		DECLARE @isValidChecklistItem BIT;

		SELECT @isValidChecklistItem = (SELECT
											TOP 1 1
										FROM
											[MTE].[Checklist] [C]
										LEFT JOIN
											[MTE].[ChecklistItem] [CI]
										ON
											[CI].[ChecklistId] = [C].[ChecklistId]
										INNER JOIN
											[MTE].[Booking] [B]
										ON
											[C].[BookingId] = [B].[BookingId]
										INNER JOIN
											[MTE].[User] [U]
										ON
											[B].[UserId] = [U].[UserId]
										WHERE
											[C].[CheckListId] = @ChecklistId
										AND
											(@ChecklistItemId = 0
											OR [CI].[ChecklistItemId] = @ChecklistItemId)
										AND
											[B].[BookingId] = @BookingId
										AND
											[B].[TripDate] >= GETUTCDATE()
										AND
											[U].[UserId] = @UserId);

		IF (@isValidChecklistItem = 1)
		BEGIN
			IF (@ChecklistItemId > 0)
			BEGIN
				SET @ChecklistItemName = ISNULL(@ChecklistItemName, (SELECT [Name] FROM [MTE].[ChecklistItem] WHERE [CheckListItemId] = @ChecklistItemId AND [CheckListId] = @ChecklistId));
				
				UPDATE
					[MTE].[ChecklistItem]
				SET
					[Name] = @ChecklistItemName,
					[IsChecked] = @IsChecked,
					[ModifiedDate] = GETUTCDATE()
				WHERE
					[CheckListItemId] = @ChecklistItemId
				AND
					[CheckListId] = @ChecklistId
			END
			ELSE
			BEGIN
				INSERT INTO
					[MTE].[ChecklistItem]
					([ChecklistId],
					[Name],
					[IsChecked],
					[ModifiedDate],
					[CreatedDate])
				
				VALUES(
					@ChecklistId,
					@ChecklistItemName,
					@IsChecked,
					GETUTCDATE(),
					GETUTCDATE());

				SELECT @CreatedChecklistItemId = (SELECT SCOPE_IDENTITY());
			END
		END
	END
GO