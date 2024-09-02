IF OBJECT_ID('MTE.GetLocationDetail', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetLocationDetail];  
GO

CREATE PROCEDURE [MTE].[GetLocationDetail]
	@LocationId INT
AS    
   SET NOCOUNT ON;

   SELECT
		[L].[LocationId],
		[L].[Name],
		[L].[Activity],
		[C].[Symbol] AS [CurrencySymbol],
		[L].[Rate],
		[L].[TotalNumberOfPerson],
		[L].[Description],
		[L].[OpeningTime],
		[L].[ClosingTime],
		[L].[Lattitude],
		[L].[Longitude],
		[L].[LocationImageUrl],
		[L].[Ticket]
	FROM
		[MTE].[Location] [L]
	INNER JOIN
		[MTE].[Currency] [C]
	ON
		[L].[CurrencyId] = [C].[CurrencyId]
	WHERE
		[L].[LocationId] = @LocationId
	AND
		[L].[IsOffice] != 1;

   RETURN;
GO 