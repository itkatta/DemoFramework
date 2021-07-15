namespace Framework.Test.Models
{
    public class Data
    {
        public double Temperature;
        public double Wind;
        public double Humidity;
        public double Pressure;
        public double Cloud;
        public double Visiblity;

        public Data(double temperature, double wind, double humidity, double pressure, double cloud, double visiblity)
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
