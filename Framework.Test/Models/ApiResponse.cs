

namespace Framework.Test.Models
{
    using System.Collections.Generic;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coord
    {
        public double Lon;
        public double Lat;
    }

    public class Weather
    {
        public int Id;
        public string Main;
        public string Description;
        public string Icon;
    }

    public class Main
    {
        public int Temp;
        public double FeelsLike;
        public double TempMin;
        public double TempMax;
        public int Pressure;
        public int Humidity;
    }

    public class Wind
    {
        public double Speed;
        public int Deg;
    }

    public class Clouds
    {
        public int All;
    }

    public class Sys
    {
        public int Type;
        public int Id;
        public string Country;
        public int Sunrise;
        public int Sunset;
    }

    public class ApiResponse
    {
        public Coord Coord;
        public List<Weather> Weather;
        public string Base;
        public Main Main;
        public int Visibility;
        public Wind Wind;
        public Clouds Clouds;
        public int Dt;
        public Sys Sys;
        public int Timezone;
        public int Id;
        public string Name;
        public int Cod;
    }


}
