IF OBJECT_ID('MTE.GetHomePageData', 'P') IS NOT NULL  
   DROP PROCEDURE [MTE].[GetHomePageData];  
GO

CREATE PROCEDURE [MTE].[GetHomePageData]
	@TotalLocation INT OUT,
	@TotalRoom INT OUT,
	@TotalStaff INT OUT
AS    
   SET NOCOUNT ON;

   SELECT @TotalLocation = (SELECT COUNT([LocationId]) FROM [MTE].[Location] WHERE [IsOffice] = 0);
   SELECT @TotalRoom = (SELECT COUNT([RoomId]) FROM [MTE].[Room]);
   SELECT @TotalStaff = (SELECT COUNT([StaffId]) FROM [MTE].[Staff]);

   EXECUTE [MTE].[GetRoomList] 1

   SELECT
		[ClientName],
		[ClientProfession],
		[Review],
		[ClientPhotoUrl]
	FROM
		[MTE].[Testimonial]

   RETURN;
GO 