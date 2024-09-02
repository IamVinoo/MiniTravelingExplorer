IF OBJECT_ID('MTE.ApplyAndValidatePromoCode', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[ApplyAndValidatePromoCode];  
GO

CREATE PROCEDURE [MTE].[ApplyAndValidatePromoCode]
	@NumberOfTicket INT,
	@PromoCode NVARCHAR(10),
	@UserId INT,
	@Rate INT,
	@DiscountedAmount INT = 0 OUTPUT,
	@PromotionValue INT = 0 OUTPUT,
	@IsPercent INT = 0 OUTPUT
AS
	SET NOCOUNT ON;

	IF(@PromoCode IS NOT NULL AND @PromoCode != '')
	BEGIN
		DECLARE @PromoInfo TABLE 
		(
			DiscountedAmount INT,
			PromotionValue INT,
			IsPercent BIT
		);

		INSERT INTO
			@PromoInfo
		SELECT
			[DiscountedAmount],
			[PromotionValue],
			[IsPercent]
		FROM
			[MTE].[ValidatePromoCode](@NumberOfTicket, @PromoCode, @UserId, @Rate);

		SELECT
			@DiscountedAmount = [DiscountedAmount],
			@PromotionValue = [PromotionValue],
			@IsPercent = [IsPercent]
		FROM
			@PromoInfo;
	END

	RETURN;
GO 