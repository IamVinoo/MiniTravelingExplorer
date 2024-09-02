IF OBJECT_ID('MTE.ValidatePromoCode', 'TF') IS NOT NULL  
   DROP FUNCTION [MTE].[ValidatePromoCode];  
GO

CREATE FUNCTION [MTE].[ValidatePromoCode] 
(
    @NumberOfTicket INT,
	@PromoCode NVARCHAR(10),
	@UserId INT,
	@Rate INT
)
RETURNS @PromotionInfo TABLE 
(
    DiscountedAmount INT,
    PromotionValue INT,
    IsPercent BIT
)
AS
BEGIN
    DECLARE @discountedAmount INT;
	DECLARE @promotionValue INT;
	DECLARE @isPercent BIT;

    SELECT
		@promotionValue = [P].[PromotionValue],
		@isPercent = [P].[IsPercent]
		FROM
			[MTE].[Subscriber] [S]
		INNER JOIN
			[MTE].[Promotion] [P]
		ON
			[S].[PromotionId] = [P].[PromotionId]

		INNER JOIN
			[MTE].[UserDetail] [UD]
		ON
			[S].[Email] = [UD].[Email]
		INNER JOIN
			[MTE].[User] [U]
		ON
			[U].[UserId] = [UD].[UserId]
		WHERE
			[P].[IsActive] = 1
		AND
			[U].[UserId] = @UserId
		AND
			LOWER([S].[PromoCode]) = LOWER(@PromoCode)
		AND
			[S].[IsActive] = 1;

	IF (@promotionValue IS NOT NULL AND @promotionValue > 0)
	BEGIN
		DECLARE @calculatedValue INT;
		SET @discountedAmount = (@NumberOfTicket * @Rate)

		IF (@isPercent = 1)
		BEGIN
			SET @calculatedValue = (@discountedAmount * @PromotionValue) / 100;
		END
		ELSE
		BEGIN
			SET @calculatedValue = @promotionValue;
		END

		IF (@calculatedValue >= @discountedAmount)
		BEGIN
			SET @discountedAmount = 0;
		END
		ELSE
		BEGIN
			SET @discountedAmount -= @calculatedValue;
		END
	END

	INSERT INTO @PromotionInfo
		([DiscountedAmount],
		 [PromotionValue],
		 [IsPercent])
    VALUES
		(@discountedAmount,
		 @promotionValue,
		 @isPercent);

    RETURN;
END;