IF OBJECT_ID('MTE.GetContactPageData', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetContactPageData];  
GO

CREATE PROCEDURE [MTE].[GetContactPageData]
AS    
   SET NOCOUNT ON;

   EXECUTE [MTE].[GetLocationData] 1;

   EXECUTE [MTE].[GetStaffList];

   RETURN;
GO 