﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationForWeatherCast
{
    public class WeatherDetailsSegment
    {

        public string Weather { get; set; }
        public string MaxTemperature { get; set; }
        public string MinTemperature { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string Humidity { get; set; }
        public string Time { get; set; }
        public string WeatherIcon { get; set; }
        public string WeatherDay { get; set; }
        public string Temperature { get; set; }
    }
}