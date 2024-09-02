using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class LocationService : BaseService
    {
        public LocationData GetLocationData(string searchString, string activitySearchString, string weatherSearchString, string minRate, string maxRate, string minTemperature, string maxTemperature)
        {
            LocationData locationData = new LocationData();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_LOCATION_DATA_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            bool isMinRateEmpty = string.IsNullOrWhiteSpace(minRate);
            bool isMaxRateEmpty = string.IsNullOrWhiteSpace(maxRate);

            sqlCommand.Parameters.Add("@SearchString", SqlDbType.NVarChar, 100).Value = searchString;
            sqlCommand.Parameters.Add("@Activity", SqlDbType.NVarChar, 500).Value = activitySearchString;
            sqlCommand.Parameters.Add("@MinRate", SqlDbType.Int).Value = !isMinRateEmpty ? Convert.ToInt32(minRate) : (object)DBNull.Value;
            sqlCommand.Parameters.Add("@MaxRate", SqlDbType.Int).Value = !isMaxRateEmpty ? Convert.ToInt32(maxRate) : (object)DBNull.Value;
            sqlCommand.Parameters.Add("@MinimumRate", SqlDbType.Int);
            sqlCommand.Parameters["@MinimumRate"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@MaximumRate", SqlDbType.Int);
            sqlCommand.Parameters["@MaximumRate"].Direction = ParameterDirection.Output;

            DataSet dataSet = new DataSet();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataSet, Constant.LOCATION_TABLE);

                if (dataSet != null)
                {
                    if (dataAdapter.SelectCommand.Parameters["@MinimumRate"].Value != DBNull.Value)
                    {
                        locationData.MinimumRate = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@MinimumRate"].Value);
                    }

                    if (dataAdapter.SelectCommand.Parameters["@MaximumRate"].Value != DBNull.Value)
                    {
                        locationData.MaximumRate = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@MaximumRate"].Value);
                    }

                    if (dataSet.Tables != null && dataSet.Tables.Count >= 3)
                    {
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();

                        if (dataSet.Tables[0] != null)
                        {
                            List<EntityModel.Location> entityLocationList = UtilFunction.DataTableToList<EntityModel.Location>(dataSet.Tables[0]);
                            locationData.LocationList = mapper.Map<List<EntityModel.Location>, List<Location>>(entityLocationList);
                        }

                        if (dataSet.Tables[1] != null)
                        {
                            List<EntityModel.Activity> activityList = UtilFunction.DataTableToList<EntityModel.Activity>(dataSet.Tables[1]);
                            locationData.Activity = mapper.Map<List<EntityModel.Activity>, List<Activity>>(activityList);
                        }

                        if (dataSet.Tables[2] != null)
                        {
                            List<EntityModel.Weather> weatherList = UtilFunction.DataTableToList<EntityModel.Weather>(dataSet.Tables[2]);
                            locationData.Weather = mapper.Map<List<EntityModel.Weather>, List<WeatherDescription>>(weatherList);
                        }
                    }
                }
            }

            if (locationData.LocationList != null && locationData.LocationList.Any())
            {
                WeatherResponse weatherResponse;
                bool isFirstItem = false;

                locationData.LocationList.ForEach(l =>
                {
                    l.MapUrl = string.Format(ConfigurationManager.AppSettings[Constant.GOOGLE_MAP_URL_KEY], l.Lattitude, l.Longitude);

                    try
                    {
                        weatherResponse = UtilFunction.GetCurrentWeather(l.Lattitude, l.Longitude);
                    }
                    catch
                    {
                        weatherResponse = null;
                    }

                    if (weatherResponse != null)
                    {
                        l.Weather = UtilFunction.GetWeatherDisplayData(weatherResponse);
                    }
                    else
                    {
                        l.Weather = new WeatherDisplay()
                        {
                            WeatherIconUrl = string.Empty,
                            Temperature = "NA",
                            Description = string.Empty,
                            IsNotAvailable = true
                        };
                    }

                    if (!isFirstItem)
                    {
                        isFirstItem = !l.Weather.IsNotAvailable;
                        l.IsFirstItem = isFirstItem;
                    }
                });

                locationData.MinimumTemperature = Convert.ToDouble(ConfigurationManager.AppSettings[Constant.MIN_TEMPERATURE_KEY]);
                locationData.MaximumTemperature = Convert.ToDouble(ConfigurationManager.AppSettings[Constant.MAX_TEMPERATURE_KEY]);

                double minimumTempearature = string.IsNullOrWhiteSpace(minTemperature) ? locationData.MinimumTemperature : Convert.ToDouble(minTemperature);
                double maximumTempearature = string.IsNullOrWhiteSpace(maxTemperature) ? locationData.MaximumTemperature : Convert.ToDouble(maxTemperature);

                if (!string.IsNullOrWhiteSpace(weatherSearchString))
                {
                    locationData.LocationList = locationData.LocationList.Where(l => l.Weather.Description.ToLower().Contains(weatherSearchString.ToLower())).ToList();
                }

                locationData.LocationList = locationData.LocationList.Where(l => l.Weather.TemperatureDouble >= minimumTempearature && l.Weather.TemperatureDouble <= maximumTempearature).ToList();
            }

            return locationData;
        }

        public Location GetLocationDetail(string locationId)
        {
            Location locationDetail = new Location();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand(Constant.GET_LOCATION_DETAIL_SP, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                dataAdapter.SelectCommand.Parameters.Add("@LocationId", SqlDbType.Int).Value = locationId;

                DataSet dataSet = new DataSet();

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.LOCATION_DETAIL);
                    DataTable dt = dataSet.Tables[Constant.LOCATION_DETAIL];
                    EntityModel.Location entityLocationDetail = UtilFunction.DataTableToObject<EntityModel.Location>(dt);
                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                    locationDetail = mapper.Map<EntityModel.Location, Location>(entityLocationDetail);
                }
            }

            if (locationDetail != null)
            {
                WeatherResponse weatherResponse;
                try
                {
                    weatherResponse = UtilFunction.GetCurrentWeather(locationDetail.Lattitude, locationDetail.Longitude);
                }
                catch
                {
                    weatherResponse = null;
                }

                if (weatherResponse != null)
                {
                    locationDetail.Weather = UtilFunction.GetWeatherDisplayData(weatherResponse);
                }
                else
                {
                    locationDetail.Weather = new WeatherDisplay()
                    {
                        WeatherIconUrl = string.Empty,
                        Temperature = "NA",
                        Description = string.Empty,
                        IsNotAvailable = true
                    };
                }
            }

            return locationDetail;
        }
    }
}