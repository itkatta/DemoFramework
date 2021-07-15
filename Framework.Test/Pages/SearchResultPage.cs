namespace Framework.Test.Pages
{
    using System;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using Framework.Selenium;
    using Framework.Test.Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class SearchResultPage : Base
    {
        public By MoreDetailsLink = By.XPath("(//span[text()='More Details'])[1]");
        public By CurrentWeather = By.XPath("//h1[text()='Current Weather']");
        public By CurrentTemperature = By.XPath("//div[@class='display-temp']");
        public By Wind = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Wind']/following-sibling::div");
        public By Humidity = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Humidity']/following-sibling::div");
        public By Pressure = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Pressure']/following-sibling::div");
        public By Cloud = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Cloud Cover']/following-sibling::div");
        public By Visiblity = By.XPath("//div[@class='detail-item spaced-content']/div[text()='Visibility']/following-sibling::div");

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

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
            double visiblity = GetVisiblity();

            return new Data(temperature, wind, humidity, pressure, cloud, visiblity);
        }

        private double GetVisiblity()
        {
            double text;
            double multiplier = 1000;

            this.IsElementDisplayedAfterWaiting(this.Visiblity).Should().BeTrue();
            Double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Visiblity)), out text).Should().BeTrue();

            return (text * multiplier);
        }

        private string GetNumberFromString(string text)
        {
            Regex reg = new Regex(@"\d+");
            return reg.Match(text).Value;
        }

        private double GetCloudData()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Cloud).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Cloud)), out text).Should().BeTrue();

            return text;
        }

        private double GetPressure()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Pressure).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Pressure)), out text).Should().BeTrue();

            return text;
        }

        private double GetHumidity()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.Humidity).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Humidity)), out text).Should().BeTrue();

            return text;
        }

        private double GetWind()
        {
            double text;
            double diviser = 3.6;

            this.IsElementDisplayedAfterWaiting(this.Wind).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.Wind)), out text).Should().BeTrue();

            return (text / diviser);
        }

        private double GetTemperature()
        {
            double text;

            this.IsElementDisplayedAfterWaiting(this.CurrentTemperature).Should().BeTrue();
            double.TryParse(GetNumberFromString(this.GetTextOfElement(this.CurrentTemperature)), out text).Should().BeTrue();

            return text;
        }
    }
}
