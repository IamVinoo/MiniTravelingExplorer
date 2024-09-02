IF OBJECT_ID('MTE.InsertUpdateSubscriber', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[InsertUpdateSubscriber];  
GO

CREATE PROCEDURE [MTE].[InsertUpdateSubscriber]
	@Email NVARCHAR(100),
	@PromoCode NVARCHAR(10),
	@PromotionId INT,
	@IsUnsubscribe BIT,
	@IsAlreadySubscribed BIT = 0 OUTPUT
AS
	DECLARE @isPromotionActive BIT = (SELECT
										[IsActive]
									  FROM
										[MTE].[Promotion]
									  WHERE
										[PromotionId] = @PromotionId);
	
	IF (@isPromotionActive = 1)
	BEGIN
		IF (@IsUnsubscribe = 1)
		BEGIN
			UPDATE
				[MTE].[Subscriber]
			SET
				[IsUnsubscribed] = @IsUnsubscribe
			WHERE
				[Email] = @Email;
		END
		ELSE
		BEGIN
			DECLARE @exisitingPromoCode NVARCHAR(20);
			DECLARE @isUnsubscribed NVARCHAR(20);
	
			SELECT
				@exisitingPromoCode = [PromoCode],
				@isUnsubscribed = [IsUnsubscribed]
			FROM
				[MTE].[Subscriber]
			WHERE
				[Email] = @Email;

			IF (@exisitingPromoCode != '' OR @exisitingPromoCode IS NOT NULL)
			BEGIN
				SELECT @IsAlreadySubscribed = 1;

				IF(@isUnsubscribed = 1)
				BEGIN
					UPDATE
						[MTE].[Subscriber]
					SET
						[IsUnsubscribed] = 0
					WHERE
						[Email] = @Email;
				END
			END
			ELSE
			BEGIN
				INSERT INTO
					[MTE].[Subscriber]
					([Email],
					[PromoCode],
					[PromotionId],
					[CreatedDate],
					[ModifiedDate])
				VALUES(
					@Email,
					@PromoCode,
					@PromotionId,
					GETUTCDATE(),
					GETUTCDATE());
			END
		END
	END
	
GO