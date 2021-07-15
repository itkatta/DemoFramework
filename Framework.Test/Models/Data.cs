namespace Framework.Test.Models
{
    /// <summary>
    /// Class for holding Data.
    /// </summary>
    public class Data
    {
        public double Temperature;
        public double Wind;
        public double Humidity;
        public double Pressure;
        public double Cloud;
        public double Visibility;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="wind">The wind.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        /// <param name="cloud">The cloud.</param>
        /// <param name="visibility">The visibility.</param>
        public Data(double temperature, double wind, double humidity, double pressure, double cloud, double visibility)
        {
            Temperature = temperature;
            Wind = wind;
            Humidity = humidity;
            Pressure = pressure;
            Cloud = cloud;
            Visibility = visibility;
        }
    }
}
