IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Activity'))
BEGIN
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Beach Day');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Beach Volleyball');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Birdwatching');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Boat Tour');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Boating');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Camel Rides');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Camping');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Canyon');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Hike');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('City Tour');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Cultural Tours');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Desert');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Safari');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Fine Dining');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Fishing');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Gondola Ride');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Guided Tours');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Harbour Cruise');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Hiking');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Historical Tour');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Medieval Banquets');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Nature Trails');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Nature Walks');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Photography');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Picnicking');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Relaxation');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Relaxing');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Scenic');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Drive');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Scuba');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Diving');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Shopping');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Sightseeing');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Skiing');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Snorkeling');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Snowboarding');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Stargazing');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Street Food Tour');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Temples Visit');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Trekking');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Vineyard Tours');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Volcano Tour');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Wildlife Watching');
	INSERT INTO [MTE].[Activity] ([Name]) VALUES ('Wine Tasting');
END