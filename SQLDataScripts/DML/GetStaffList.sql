IF OBJECT_ID('MTE.GetStaffList', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetStaffList];  
GO

CREATE PROCEDURE [MTE].[GetStaffList]
AS    
   SET NOCOUNT ON;

   SELECT
		[StaffId],
		[Name],
		[Designation],
		[LinkedInUrl],
		[FacebookUrl],
		[InstagramUrl],
		[StaffImage],
		[StaffImageType]
	FROM
		[MTE].[Staff];

   RETURN;
GO 