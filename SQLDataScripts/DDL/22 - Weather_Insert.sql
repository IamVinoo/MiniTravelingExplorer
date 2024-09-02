IF (EXISTS (SELECT * 
                 FROM [INFORMATION_SCHEMA].[TABLES] 
                 WHERE [TABLE_SCHEMA] = 'MTE'
				 AND [TABLE_NAME] = 'Weather'))
BEGIN
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Clear sky');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Few clouds');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Scattered clouds');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Broken clouds');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Shower rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Mist');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with light rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with heavy rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light thunderstorm');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy thunderstorm');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Ragged thunderstorm');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with light drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Thunderstorm with heavy drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light intensity drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy intensity drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light intensity drizzle rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy intensity drizzle rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Shower rain and drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy shower rain and drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Shower drizzle');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Moderate rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Very heavy rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Extreme rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Freezing rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light intensity shower rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy intensity shower rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Ragged shower rain');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Sleet');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light shower sleet');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Shower sleet');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Rain and snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light rain and snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Light shower snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Shower snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Heavy shower snow');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Smoke');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Haze');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Sand/dust whirls');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Fog');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Sand');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Dust');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Volcanic ash');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Squalls');
	INSERT INTO [MTE].[Weather] ([Name]) VALUES ('Tornado'); 
END