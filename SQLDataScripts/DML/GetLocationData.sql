IF OBJECT_ID('MTE.GetLocationData', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetLocationData];  
GO

CREATE PROCEDURE [MTE].[GetLocationData]
	@IsOffice BIT = 0,
	@SearchString NVARCHAR(100) = '',
	@Activity NVARCHAR(500) = '',
	@MinRate INT = NULL,
	@MaxRate INT = NULL,
	@MinimumRate INT = NULL OUTPUT,
	@MaximumRate INT = NULL OUTPUT
AS    
   SET NOCOUNT ON;
   
	SELECT
		@MinimumRate = MIN([Rate]),
		@MaximumRate = MAX([Rate])
	FROM
		[MTE].[Location]
	WHERE
		[IsOffice] = @IsOffice;

	SET @MinRate = ISNULL(@MinRate, @MinimumRate);
	SET	@MaxRate = ISNULL(@MaxRate, @MaximumRate);

   SELECT
		[L].[LocationId],
		[L].[Name],
		[L].[Activity],
		[C].[Symbol] AS [CurrencySymbol],
		[L].[Rate],
		[L].[TotalNumberOfPerson],
		[L].[Description],
		[L].[Lattitude],
		[L].[Longitude],
		[L].[LocationImageUrl]
	FROM
		[MTE].[Location] [L]
	INNER JOIN
		[MTE].[Currency] [C]
	ON
		[L].[CurrencyId] = [C].[CurrencyId]
	WHERE
		[L].[IsOffice] = @IsOffice
		AND	(@SearchString = ''
		OR [L].[Name] LIKE '%' + @SearchString + '%'
		OR [L].[Description] LIKE '%' + @SearchString + '%')
		AND (@Activity = ''
		OR [L].[Activity] LIKE '%' + @Activity + '%')
		AND [L].[Rate] BETWEEN @MinRate AND @MaxRate;

	IF(@IsOffice = 0)
	BEGIN
		SELECT
			[ActivityId],
			[Name]
		FROM
			[MTE].[Activity];

		SELECT
			[WeatherId],
			[Name]
		FROM
			[MTE].[Weather];
	END
   RETURN;
GO 