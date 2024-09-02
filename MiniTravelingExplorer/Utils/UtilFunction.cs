using System.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using MiniTravelingExplorer.Models;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Diagnostics;
using SystemIO = System.IO;

namespace MiniTravelingExplorer.Utils
{
    public static class UtilFunction
    {
        public static T DataTableToObject<T>(DataTable table) where T : new()
        {
            // create a new object
            T obj = new T();

            if (table != null && table.Rows?.Count > 0)
            {
                //change made at this line
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(table.Rows[0][prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            // return 
            return obj;
        }

        public static List<T> DataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (DataRow row in table.Rows)
                {
                    T obj = new T();
                    //change made at this line
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetColumnName(DataTable table)
        {
            List<string> columnName = new List<string>();

            if(table != null && table.Rows.Count > 0)
            {
                foreach (DataColumn column in table.Columns)
                {
                    columnName.Add(column.ColumnName);
                }
            }

            return columnName;
        }

        public static GoogleRecaptchaResponse ValidateGoogleRecaptchaResponse(string encodedResponse)
        {
            GoogleRecaptchaResponse googleRecaptchaResponse = new GoogleRecaptchaResponse();

            if (!string.IsNullOrEmpty(encodedResponse))
            {
                string googleReply = new WebClient().DownloadString(string.Format(string.Format(ConfigurationManager.AppSettings[Constant.GOOGLE_RECAPTCHA_API_URL_PARAMETERS_KEY], ConfigurationManager.AppSettings[Constant.GOOGLE_RECAPTCHA_API_URL_KEY].ToString(), ConfigurationManager.AppSettings[Constant.GOOGLE_RECAPTCHA_SECRET_KEY].ToString(), encodedResponse)));

                if (!string.IsNullOrEmpty(googleReply))
                {
                    googleRecaptchaResponse = JsonConvert.DeserializeObject<GoogleRecaptchaResponse>(googleReply);
                }
            }
            else
            {
                googleRecaptchaResponse.ErrorCodes = new List<string>
                {
                    Constant.GOOGLE_RECAPTCHA_INVALID_ERROR_MESSAGE
                };
            }

            return googleRecaptchaResponse;
        }

        public static string GetFileDataFromBytes(byte[] data, string fileType)
        {
            string convertedBase64 = string.Empty;

            if (data != null && data.Length > 0)
            {
                convertedBase64 = string.Concat(fileType, Convert.ToBase64String(data, 0, data.Length));
            }

            return convertedBase64;
        }

        public static string GetFileData(string filePath)
        {
            string fileData = string.Empty;

            if (SystemIO.File.Exists(filePath))
            {
                fileData = SystemIO.File.ReadAllText(filePath);
            }

            return fileData;
        }

        public static string EncryptString(string textToEncrypt)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(textToEncrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ConfigurationManager.AppSettings[Constant.ENCRYTION_KEY], new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (SystemIO.MemoryStream ms = new SystemIO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    textToEncrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textToEncrypt;
        }

        public static string DecryptString(string encryptedText)
        {
            try
            {
                encryptedText = encryptedText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(encryptedText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ConfigurationManager.AppSettings[Constant.ENCRYTION_KEY], new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (SystemIO.MemoryStream ms = new SystemIO.MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        encryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return encryptedText;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string HashPassword(string password, string saltKey)
        {
            string hashedPassword = string.Empty;

            if (!string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(saltKey))
            {
                hashedPassword = Crypto.HashPassword(ConcatPasswordForHashing(password, saltKey));
            }

            return hashedPassword;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password, string saltKey)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(hashedPassword) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(saltKey))
            {
                isValid = Crypto.VerifyHashedPassword(hashedPassword, ConcatPasswordForHashing(password, saltKey));
            }

            return isValid;
        }

        public static string RandomNumberGenerator(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue).ToString();
        }

        public static string ReplaceString(string sourceString, string stringToReplace, string replacingString)
        {
            string replacedFinalString = string.Empty;

            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                replacedFinalString = sourceString.Replace(stringToReplace, replacingString);
            }

            return replacedFinalString;
        }

        public static void GetControllerActionFromUrl(string url, out string controller, out string action)
        {
            controller = Constant.HOME_CONTROLLER;
            action = Constant.HOME_ACTION;

            if (!string.IsNullOrWhiteSpace(url))
            {
                List<string> urlList = url.Split(Convert.ToChar(Constant.FORWARD_SLASH)).ToList();
                urlList.Remove(string.Empty);

                if (urlList.Count == 2)
                {
                    controller = urlList[0];
                    action = urlList[1];
                }
            }
        }

        public static string GetWebResponse(string url, string requestMethod)
        {
            string responseData = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = requestMethod;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (SystemIO.Stream responseStream = response.GetResponseStream())
                    {
                        SystemIO.StreamReader reader = new SystemIO.StreamReader(responseStream);
                        responseData = reader.ReadToEnd();

                    }
                }
            }

            return responseData;
        }

        public static WeatherResponse GetCurrentWeather(string lattitude, string longitude, string units = "")
        {
            WeatherResponse weatherResponse = new WeatherResponse();

            if (string.IsNullOrWhiteSpace(units))
            {
                units = Constant.METRIC_UNIT;
            }

            string weatherResponseData = GetWebResponse(string.Format(ConfigurationManager.AppSettings[Constant.OPEN_WEATHER_API_URL_KEY], ConfigurationManager.AppSettings[Constant.OPEN_WEATHER_API_KEY_KEY], lattitude, longitude, units), Constant.GET_REQUEST_METHOD);

            if (!string.IsNullOrEmpty(weatherResponseData))
            {
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(weatherResponseData);
            }

            return weatherResponse;
        }

        public static WeatherDisplay GetWeatherDisplayData(WeatherResponse weatherResponse)
        {
            WeatherDisplay weatherDisplay = new WeatherDisplay();

            if (weatherResponse != null)
            {
                DateTime sunriseTime = UnixTimeStampToDateTime(weatherResponse.Sys.Sunrise, weatherResponse.Timezone);
                DateTime sunsetTime = UnixTimeStampToDateTime(weatherResponse.Sys.Sunset, weatherResponse.Timezone);

                weatherDisplay.WeatherIconUrl = string.Format(ConfigurationManager.AppSettings[Constant.OPEN_WEATHER_ICON_URL_KEY], weatherResponse.Weather?.FirstOrDefault()?.Icon);

                double temperature = Math.Round(weatherResponse.Main.Temp);
                weatherDisplay.TemperatureDouble = temperature;
                weatherDisplay.Temperature = GetTemperatueDisplayString(temperature);

                weatherDisplay.FeelsLikeTemperature = GetTemperatueDisplayString(Math.Round(weatherResponse.Main.Feels_like));
                weatherDisplay.MinimumTemperature = GetTemperatueDisplayString(Math.Round(weatherResponse.Main.Temp_min));
                weatherDisplay.MaximumTemperature = GetTemperatueDisplayString(Math.Round(weatherResponse.Main.Temp_max));
                weatherDisplay.Description = weatherResponse.Weather?.FirstOrDefault()?.Description;
                weatherDisplay.CloudPercentage = string.Concat(weatherResponse.Clouds.All.ToString(), Constant.PERCENTAGE);
                weatherDisplay.Wind = GetWindDisplayString(weatherResponse.Wind?.Speed);
                weatherDisplay.WindDirection = GetWindDirection(weatherResponse.Wind?.Deg);
                weatherDisplay.Gust = GetWindDisplayString(weatherResponse.Wind?.Gust);
                weatherDisplay.Pressure = string.Concat(weatherResponse.Main.Pressure.ToString(), Constant.PRESSURE_UNIT);
                weatherDisplay.SunriseTime = sunriseTime.ToString(Constant.HH_MM_TT_TIME_FORMAT);
                weatherDisplay.SunsetTime = sunsetTime.ToString(Constant.HH_MM_TT_TIME_FORMAT);
                weatherDisplay.IsDay = GetIsDay(weatherResponse.Timezone, sunriseTime, sunsetTime);
                weatherDisplay.Url = string.Format(ConfigurationManager.AppSettings[Constant.OPEN_WEATHER_CITY_URL_KEY], weatherResponse.Id);
            }

            return weatherDisplay;
        }

        public static string GetTemperatueDisplayString(double temperature)
        {
            return string.Concat(temperature, Constant.DEGREE_CHARACTER, Constant.C_CHARACTER);
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp, long timeZone)
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTime = epochStart.AddSeconds(unixTimeStamp);

            TimeSpan offset = TimeSpan.FromSeconds(timeZone);
            return dateTime += offset;
        }

        public static bool GetIsDay(long timezoneOffsetSeconds, DateTime sunriseTime, DateTime sunsetTime)
        {
            DateTime currentTime = DateTime.UtcNow.AddSeconds(timezoneOffsetSeconds);
            return currentTime > sunriseTime && currentTime < sunsetTime;
        }

        public static string GetWindDisplayString(double? windSpeed)
        {
            return string.Concat(GetSpeedInKmh(windSpeed.Value).ToString(), Constant.STRING_WHITE_SPACE, Constant.SPEED_KMH_UNIT);
        }

        public static double GetSpeedInKmh(double speedInMps)
        {
            return Math.Round(speedInMps * Convert.ToDouble(Constant.SPEED_CONVERSION_FACTOR), 2);
        }

        public static string GetWindDirection(int? degrees)
        {
            int index = Convert.ToInt32(Math.Round(degrees.Value / 22.5) % 16);
            return GetDirections()[index];
        }

        public static string[] GetDirections()
        {
            string[] directions =
            {
                Constant.NORTH_DIRECTION,
                Constant.NORTH_NORTH_EAST_DIRECTION,
                Constant.NORTH_EAST_DIRECTION,
                Constant.EAST_NORTH_EAST_DIRECTION,
                Constant.EAST_DIRECTION,
                Constant.EAST_SOUTH_EAST_DIRECTION,
                Constant.SOUTH_EAST_DIRECTION,
                Constant.SOUTH_SOUTH_EAST_DIRECTION,
                Constant.SOUTH_DIRECTION,
                Constant.SOUTH_SOUTH_WEST_DIRECTION,
                Constant.SOUTH_WEST_DIRECTION,
                Constant.WEST_SOUTH_WEST_DIRECTION,
                Constant.WEST_DIRECTION,
                Constant.WEST_NORTH_WEST_DIRECTION,
                Constant.NORTH_WEST_DIRECTION,
                Constant.NORTH_NORTH_WEST_DIRECTION
            };

            return directions;
        }

        public static List<Room> SetRoomCardAnimationTimeDelay(List<Room> roomList)
        {
            if (roomList.Any())
            {
                int count = 1;
                float animationDelayTime = 0.1f;

                foreach (Room room in roomList)
                {
                    if (count == 1)
                    {
                        animationDelayTime = 0.1f;
                    }
                    else if (count == 3)

                    {
                        count = 0;
                        animationDelayTime *= 2;
                    }
                    else
                    {
                        animationDelayTime += animationDelayTime * 2;
                    }

                    room.AnimationDelayTime = string.Concat(animationDelayTime, Constant.S_CHARACTER.ToLower());
                    count++;
                }
            }

            return roomList;
        }

        public static string GeneratePromoCode()
        {
            Random random = new Random();
            StringBuilder promoCodeBuilder = new StringBuilder();
            string alpha_characters = Constant.ALPHABETICAL_CHARACTERS;
            string numeric_characters = Constant.NUMERIC_CHARACTERS;

            for (int i = 0; i < 3; i++)
            {
                promoCodeBuilder.Append(alpha_characters[random.Next(alpha_characters.Length)]);
            }

            for (int i = 0; i < 2; i++)
            {
                promoCodeBuilder.Append(numeric_characters[random.Next(numeric_characters.Length)]);
            }

            return promoCodeBuilder.ToString();
        }

        public static string CustomTimespanFormat(TimeSpan timeSpan)
        {
            string formattedTimeSpan = string.Empty;

            if(timeSpan != null)
            {
                formattedTimeSpan = DateTime.Today.Add(timeSpan).ToString(Constant.HH_MM_TT_TIME_FORMAT);
            }

            return formattedTimeSpan;
        }

        public static string GenerateTicketNumber()
        {
            Random random = new Random();
            StringBuilder ticketNumberBuilder = new StringBuilder();
            const string chars = Constant.ALPHABETICAL_CHARACTERS;

            for (int i = 0; i < 15; i++)
            {
                ticketNumberBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return ticketNumberBuilder.ToString();
        }

        public static string FormatCardNumber(string cardNumber)
        {
            string formattedCardNumber = string.Empty;
            for (int i = 0; i <= cardNumber.Length - 5; i++)
            {
                if (!string.IsNullOrWhiteSpace(cardNumber[i].ToString()))
                {
                    formattedCardNumber += Constant.X_CHARACTER;
                }
                else
                {
                    formattedCardNumber += cardNumber[i];
                }
            }

            if (!string.IsNullOrWhiteSpace(cardNumber))
            {
                formattedCardNumber += cardNumber.Substring(cardNumber.Length - 4);
            }

            return formattedCardNumber;
        }

        public static string ConcatLogMessage(string message)
        {
            return string.Concat(new StackTrace().GetFrame(1).GetMethod().Name, Constant.STRING_WHITE_SPACE, Constant.COLON_CHARACTER, Constant.STRING_WHITE_SPACE, message);
        }

        private static string ConcatPasswordForHashing(string password, string saltKey)
        {
            return string.Concat(password, Constant.ASTERISK, saltKey);
        }
    }
}