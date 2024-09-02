IF OBJECT_ID('MTE.GetLocationList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetLocationList];  
GO

CREATE PROCEDURE [MTE].[GetLocationList]
	@IsOffice BIT = 0,
	@SearchString NVARCHAR(100) = '',
	@Activity NVARCHAR(500) = '',
	@MinRate INT = NULL,
	@MaxRate INT = NULL
AS    
   SET NOCOUNT ON;
   
	SELECT
		@MinRate = ISNULL(@MinRate, MIN([Rate])),
		@MaxRate = ISNULL(@MaxRate, MAX([Rate]))
	FROM
		[MTE].[Location];

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
		AND [L].[Rate] BETWEEN @MinRate AND @MaxRate
   RETURN;
GO 