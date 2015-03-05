# Project-For-weather
Aplicacion desarrollda en C#, usando el API  de http://openweathermap.org/.
La funcionalidad de la aplicación es poder saber el tiempo en las ciudades de: Caracas, Singapur, Santiago, New York, Osaka


La aplicación esta desarrollada C# de la siguiente forma:

Web control default.aspx:

-En el client-side se encuentran los diferentes controles que dan la interfaz a la aplicación.
- DropDownList el cual es un desplegable de IdNombre "ddlElegirCiudad", el cual proporciona las diferentes opciones de ciudades a elegir para conocer la temperatura en las diferentes localidades. este control tiene un evento (onselectedindexchanged="ddlWeatherCast_SelectedIndexChanged") el cual se dispara en el server-side para correr las instrucciones que permitiran mostrar la informacion deseada en los label's(lbltime,Temperatura,lblTempPromdio) que se encuentran en el client-side.

Server-side  default.aspx.cs:

-En el server-side tenemos:

-El evento  ddlWeatherCast_SelectedIndexChanged Se dispara en el momento en que se selecciona una ciudad en el desplegable "ddlElegirCiudad" y tiene como función:

-La invocación a la Api  openweathermap a través del url nos otorga la información solicitada en data XML. La data es leída a través de la clase XElement y luego asignada a los objetos de la clase WeatherDetailsSegment.cs, para luego ser asignadas a los controles label.

-Para obtener el dato temperatura promedio sumamos los valores que se encuentran en el objeto temperatura dentro de la lista "listObjWeather".
