using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ClientServices;
using System.Xml;
using System.Net;
using System.Web.Services;
using System.Globalization;
using System.Xml.Linq;

namespace WebApplicationForWeatherCast
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlWeatherCast_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Ciudad = ddlWeatherCast.SelectedValue;

            if (Ciudad != "[Elegir]")
            {

                string datos_invocador1 = new WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast/daily?q={" + Ciudad + "}&type=accurate&mode=xml&units=metric&cnt=3&appid={6c6a6bf05b638040f0dc14e9b41a4168}");// + AppID);

                XElement xEl = XElement.Load(new System.IO.StringReader(datos_invocador1));
                List<WeatherDetailsSegment> listObjWeather = GetWeatherInfo(xEl);

                Temperatura.Text = listObjWeather.ElementAt(0).Temperature;
                lbltime.Text = listObjWeather.ElementAt(0).Time;


                IFormatProvider format = new CultureInfo("es-VE");
                DateTime dateTime = DateTime.Parse(listObjWeather.ElementAt(0).Time, format, DateTimeStyles.None);

                string[] dateTimeProc = dateTime.ToString().Split(' ');
                lbltime.Text = dateTimeProc[0];

                int contador = 0;
                decimal TempProc = 0;
                decimal TempProcWh = 0;
                string trabajarCadenasStrg;
                decimal TempProcWhTotal = 0;
                while (contador < listObjWeather.Count())
                {

                    trabajarCadenasStrg = TrabajarCadenas(listObjWeather.ElementAt(contador).Temperature);
                    TempProcWh = decimal.Parse(trabajarCadenasStrg);

                    TempProcWhTotal += TempProcWh;

                    contador++;
                }

                decimal cantDays = listObjWeather.Count();
                TempProc = TempProcWhTotal; 
                TempProc = Math.Round((TempProc / cantDays), 2, MidpointRounding.AwayFromZero);
                lblTempPromdio.Text = TempProc.ToString().Replace(',', '.') + "°";
            }

            else
            {
                Temperatura.Text = "";
                lbltime.Text = "";
                lblTempPromdio.Text = "";

            }
        }

        private static List<WeatherDetailsSegment> GetWeatherInfo(XElement xEl)
        {
            IEnumerable<WeatherDetailsSegment> w = xEl.Descendants("time").Select((el) =>
                new WeatherDetailsSegment
                {
                    Temperature = el.Element("temperature").Attribute("day").Value + "°",
                    Time = el.Attribute("day").Value
                });

            return w.ToList();
        }


        public string TrabajarCadenas(string Valor)
        {
            string sinGrado = Valor.Replace('°', ' ');
            string ChpuntoComa = sinGrado.Replace('.', ',');

            Valor = ChpuntoComa;

            return Valor;
        }

    }
}
