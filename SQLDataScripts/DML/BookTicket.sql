IF OBJECT_ID('MTE.BookTicket', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[BookTicket];  
GO

CREATE PROCEDURE [MTE].[BookTicket]
	@LocationId INT,
	@UserId INT,
	@BookingEmail NVARCHAR(100),
	@TicketNumber NVARCHAR(100),
	@NumberOfTicket INT,
	@CardNumber NVARCHAR(20),
	@CardName NVARCHAR(50),
	@TripDate DATETIME,
	@BookingId INT = 0 OUTPUT,
	@PromoCode NVARCHAR(10) = '',
	@IsValidPromoCode BIT = 1 OUTPUT,
	@AmountDisplay NVARCHAR(100) = '' OUTPUT
AS
	DECLARE @IsPromoCodeEntered BIT = 0;
	DECLARE @discountedAmount INT;
	DECLARE @currencyId INT;
	DECLARE @availableTicket INT;
	DECLARE @rate INT;

	SELECT
		@rate = [Rate],
		@currencyId = [CurrencyId],
		@availableTicket = [Ticket]
	FROM
		[MTE].[Location]
	WHERE
		[LocationId] = @LocationId;

	IF (@PromoCode IS NOT NULL AND LTRIM(RTRIM(@PromoCode)) != '')
	BEGIN
		SET @IsPromoCodeEntered = 1;

		EXECUTE [MTE].[ApplyAndValidatePromoCode] 
				@NumberOfTicket = @NumberOfTicket, 
				@PromoCode = @PromoCode, 
				@UserId = @UserId, 
				@Rate = @rate, 
				@discountedAmount = @discountedAmount OUTPUT;

		SELECT @discountedAmount AS DiscountedAmount;

		IF (@discountedAmount IS NULL OR @discountedAmount <= 0)
		BEGIN
			SET @IsValidPromoCode = 0;
		END
		ELSE
		BEGIN
			SET @IsValidPromoCode = 1;
		END
	END

	IF(@IsPromoCodeEntered = 0 OR @IsValidPromoCode = 1)
	BEGIN
		IF(ISNULL(@rate,0) > 0 AND ISNULL(@currencyId,0) > 0 AND @availableTicket >= @NumberOfTicket)
		BEGIN
			DECLARE @maxBookingId INT;
			DECLARE @amount INT;

			SELECT @maxBookingId = (SELECT MAX([BookingId]) FROM [MTE].[Booking]);
			SELECT @amount = CASE
							 WHEN
								@IsValidPromoCode = 1
							 THEN
								@discountedAmount
							 ELSE
								@NumberOfTicket * @rate
							 END;

			INSERT INTO
				[MTE].[Booking]
				([LocationId],
				[UserId],
				[BookingEmail],
				[TicketNumber],
				[NumberOfTicket],
				[Amount],
				[CurrencyId],
				[CardNumber],
				[CardName],
				[TripDate])
			VALUES(
				@LocationId,
				@UserId,
				@BookingEmail,
				@TicketNumber,
				@NumberOfTicket,
				@amount,
				@currencyId,
				@CardNumber,
				@CardName,
				@TripDate
				);

			SET @BookingId = SCOPE_IDENTITY();
		
			SET @AmountDisplay = CONCAT((SELECT
											[Symbol]
										 FROM
											[MTE].[Currency]
										 WHERE
											[CurrencyId] = @currencyId)
										, ROUND(CAST(@amount AS DECIMAL(18,2)), 2));

			IF (@BookingId > @maxBookingId)
			BEGIN
				SET @availableTicket -= @NumberOfTicket;

				IF (@availableTicket < 0)
				BEGIN
					SET @availableTicket = 0;
				END

				UPDATE
					[MTE].[Location]
				SET
					[Ticket] = @availableTicket
				WHERE
					[LocationId] = @LocationId;

				IF (@IsPromoCodeEntered = 1)
				BEGIN
					UPDATE
						[MTE].[Subscriber]
					SET
						[IsActive] = 0
					FROM
						[MTE].[Subscriber] [S]
					INNER JOIN
						[MTE].[UserDetail] [UD]
					ON
						[S].[Email] = [UD].[Email]
					INNER JOIN
						[MTE].[User] [U]
					ON
						[U].[UserId] = [UD].[UserId]
					WHERE
						[U].[UserId] = @UserId
					AND
						[S].[Email] = [UD].[Email]
					AND
						LOWER([PromoCode]) = LOWER(@PromoCode)
				END
			END
		END
	END
	RETURN;
GO 