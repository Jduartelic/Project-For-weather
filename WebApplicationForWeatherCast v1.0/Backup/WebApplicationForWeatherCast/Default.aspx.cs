using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ClientServices;


using System.Xml;

using System.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Xml;

using System.Globalization;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Drawing.Drawing2D; 

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Windows.Input;
//using OpenWeather.Model;
//using OpenWeather.Command;
//using OpenWeather.HelperClass;

namespace WebApplicationForWeatherCast
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlWeatherCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AppID = "&APPID=6c6a6bf05b638040f0dc14e9b41a4168";

            string Ciudad = ddlWeatherCast.SelectedValue;
            
            string datos_invocador1 = new WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast/daily?q={"+Ciudad+"}&type=accurate&mode=xml&units=metric&cnt=3&appid={6c6a6bf05b638040f0dc14e9b41a4168}");// + AppID);

            XElement xEl = XElement.Load(new System.IO.StringReader(datos_invocador1));
            List<WeatherDetailsSegment> listObjWeather = GetWeatherInfo(xEl);

            Humedad.Text = listObjWeather.ElementAt(0).Humidity;
            MaxTemp.Text = listObjWeather.ElementAt(0).MaxTemperature;
            MinTemp.Text = listObjWeather.ElementAt(0).MinTemperature;
            Temperatura.Text = listObjWeather.ElementAt(0).Temperature;
            WindSpeed.Text = listObjWeather.ElementAt(0).Time;

            var query = from item in listObjWeather
                        group item by new{TempPr=item.Temperature} into g
                        select new
                        {
                            TempPro = g.Sum(x => decimal.Parse(x.Temperature))
                        };
            decimal cantDays = listObjWeather.Count();
            decimal TempProc = query.ElementAt(0).TempPro;
            TempProc = TempProc / cantDays;
            TemperaturaPromedio.Text = TempProc.ToString();
        }


        private static List<WeatherDetailsSegment> GetWeatherInfo(XElement xEl)
        {
            IEnumerable<WeatherDetailsSegment> w = xEl.Descendants("time").Select((el) =>
                new WeatherDetailsSegment
                {
                    Humidity = el.Element("humidity").Attribute("value").Value + "%",
                    MaxTemperature = el.Element("temperature").Attribute("max").Value + "°",
                    MinTemperature = el.Element("temperature").Attribute("min").Value + "°",
                    Temperature = el.Element("temperature").Attribute("day").Value + "°",
                    Weather = el.Element("symbol").Attribute("name").Value,
                    //WeatherDay = DayOfTheWeek(el),
                    //WeatherIcon = WeatherIconPath(el),
                    WindDirection = el.Element("windDirection").Attribute("name").Value,
                    WindSpeed = el.Element("windSpeed").Attribute("mps").Value + "mps",
                    Time = el.Attribute("day").Value
                });

            return w.ToList();
        }
    }
}
