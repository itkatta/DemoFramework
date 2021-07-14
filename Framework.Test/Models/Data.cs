namespace Framework.Test.Models
{
    public class Data
    {
        public decimal Temperature;
        public decimal Wind;
        public decimal Humidity;
        public decimal Pressure;
        public decimal Cloud;
        public decimal Visiblity;

        public Data(decimal temperature, decimal wind, decimal humidity, decimal pressure, decimal cloud, decimal visiblity)
        {
            Temperature = temperature;
            Wind = wind;
            Humidity = humidity;
            Pressure = pressure;
            Cloud = cloud;
            Visiblity = visiblity;
        }
    }
}
