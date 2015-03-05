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
        int contador = 0;
        string ValorTemperaturaStrg;
        decimal ValorTemperaturaPromedio = 0;
        decimal SumaValorTemperaturaPromedio = 0;
        decimal ValorTemperaturaPromedioTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlWeatherCast_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Ciudad = ddlElegirCiudad.SelectedValue;

            if (Ciudad != "[Elegir]")
            {

                string DatosInvocador = new WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast/daily?q={" + Ciudad + "}&type=accurate&mode=xml&units=metric&cnt=3&appid={6c6a6bf05b638040f0dc14e9b41a4168}");

                XElement xEl = XElement.Load(new System.IO.StringReader(DatosInvocador));
                List<WeatherDetailsSegment> listObjWeather = GetWeatherInfo(xEl);

                Temperatura.Text = listObjWeather.ElementAt(0).Temperatura;
                lbltime.Text = listObjWeather.ElementAt(0).FechaActual;


                IFormatProvider format = new CultureInfo("es-VE");
                DateTime FechaActualFormat = DateTime.Parse(listObjWeather.ElementAt(0).FechaActual, format, DateTimeStyles.None);

                string[] SplitFechaActualFormat = FechaActualFormat.ToString().Split(' ');
                lbltime.Text = SplitFechaActualFormat[0];
                                
                while (contador < listObjWeather.Count())
                {

                    ValorTemperaturaStrg = TrabajarCadenas(listObjWeather.ElementAt(contador).Temperatura);
                    ValorTemperaturaPromedio = decimal.Parse(ValorTemperaturaStrg);

                    SumaValorTemperaturaPromedio += ValorTemperaturaPromedio;

                    contador++;
                }

                decimal cantDays = listObjWeather.Count();
                ValorTemperaturaPromedioTotal = SumaValorTemperaturaPromedio;
                ValorTemperaturaPromedioTotal = Math.Round((ValorTemperaturaPromedioTotal / cantDays), 2, MidpointRounding.AwayFromZero);
                lblTempPromdio.Text = ValorTemperaturaPromedioTotal.ToString().Replace(',', '.') + "°";
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
                    Temperatura = el.Element("temperature").Attribute("day").Value + "°",
                    FechaActual = el.Attribute("day").Value
                });

            return w.ToList();
        }


        public string TrabajarCadenas(string Valor)
        {
            string sinGrado = Valor.Replace('°', ' ');
            string ComaPorPunto = sinGrado.Replace('.', ',');

            Valor = ComaPorPunto;

            return Valor;
        }

    }
}
