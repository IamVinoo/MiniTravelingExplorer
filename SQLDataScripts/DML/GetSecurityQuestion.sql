IF OBJECT_ID('MTE.GetSecurityQuestion', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetSecurityQuestion];  
GO

CREATE PROCEDURE [MTE].[GetSecurityQuestion]
AS    
   SET NOCOUNT ON;

   SELECT
		[SecurityQuestionId],
		[SecurityQuestion]
	FROM
		[MTE].[SecurityQuestion]
   
   RETURN;
GO 