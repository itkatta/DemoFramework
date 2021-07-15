namespace Framework.Test.Pages
{
    using System;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using Framework.Selenium;
    using Framework.Test.Models;
    using OpenQA.Selenium;

    /// <summary>
    /// Class contains Search result page mapped objects and interactions.
    /// </summary>
    /// <seealso cref="Framework.Selenium.Base" />
    public class SearchResultPage : Base
    {
        /// <summary>
        /// The more details link.
        /// </summary>
        public By MoreDetailsLink = By.XPath("(//span[text()='More Details'])[1]");

        /// <summary>
        /// The current weather.
        /// </summary>
        public By CurrentWeather = By.XPath("//h1[text()='Current Weather']");

        /// <summary>
        /// The current temperature.
        /// </summary>
        public By CurrentTemperature = By.XPath("//div[@class='display-temp']");

        /// <summary>
        /// The wind
        /// </summary>
        public By Wind = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Wind']/following-sibling::div");

        /// <summary>
        /// The humidity
        /// </summary>
        public By Humidity = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Humidity']/following-sibling::div");

        /// <summary>
        /// The pressure
        /// </summary>
        public By Pressure = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Pressure']/following-sibling::div");

        /// <summary>
        /// The cloud
        /// </summary>
        public By Cloud = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Cloud Cover']/following-sibling::div");

        /// <summary>
        /// The visiblity
        /// </summary>
        public By Visiblity = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Visibility']/following-sibling::div");

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResultPage"/> class.
        /// </summary>
        /// <param name="driver"></param>
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Gets the data from UI.
        /// </summary>
        /// <returns></returns>
        internal Data GetDataFromUi()
        {
            this.ClickOnClickableElement(this.MoreDetailsLink);
            this.Driver.Navigate().Refresh();
            this.ClickOnClickableElement(this.MoreDetailsLink);
            this.IsElementDisplayedAfterWaiting(CurrentWeather).Should().BeTrue();

            double temperature = Double.Parse(this.GetTemperature().ToString());
            double wind = Double.Parse(Math.Round(this.GetWind(),2).ToString());
            double humidity = this.GetHumidity();
            double pressure = GetPressure();
            double cloud = GetCloudData();
            double visiblity = GetVisibility();

            return new Data(temperature, wind, humidity, pressure, cloud, visiblity);
        }

        /// <summary>
        /// Gets the visibility.
        /// </summary>
        /// <returns></returns>
        private double GetVisibility()
        {
            double text;
            double multiplier = 1000;

            this.IsElementDisplayedAfterWaiting(this.Visiblity).Should().BeTrue();
            Double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Visiblity)), out text).Should().BeTrue();

            return (text * multiplier);
        }

        /// <summary>
        /// Gets the number from string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private string GetNumberFromString(string text)
        {
            Regex reg = new Regex(@"\d+");
            return reg.Match(text).Value;
        }

        /// <summary>
        /// Gets the cloud data.
        /// </summary>
        /// <returns></returns>
        private double GetCloudData()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Cloud).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Cloud)), out text).Should().BeTrue();

            return text;
        }

        /// <summary>
        /// Gets the pressure.
        /// </summary>
        /// <returns></returns>
        private double GetPressure()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Pressure).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Pressure)), out text).Should().BeTrue();

            return text;
        }

        /// <summary>
        /// Gets the humidity.
        /// </summary>
        /// <returns></returns>
        private double GetHumidity()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Humidity).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Humidity)), out text).Should().BeTrue();

            return text;
        }

        /// <summary>
        /// Gets the wind.
        /// </summary>
        /// <returns></returns>
        private double GetWind()
        {
            double text;
            double diviser = 3.6;

            this.IsElementDisplayedAfterWaiting(this.Wind).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Wind)), out text).Should().BeTrue();

            return (text / diviser);
        }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <returns></returns>
        private double GetTemperature()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.CurrentTemperature).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.CurrentTemperature)), out text).Should().BeTrue();

            return text;
        }
    }
}
