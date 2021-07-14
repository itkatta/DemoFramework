namespace Framework.Test.Pages
{
    using System;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using Framework.Selenium;
    using Framework.Test.Models;
    using OpenQA.Selenium;

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
            this.IsElementDisplayedAfterWaiting(CurrentWeather).Should().BeTrue();

            decimal temperature = this.GetTemperature();
            decimal wind = this.GetWind();
            decimal humidity = this.GetHumidity();
            decimal pressure = GetPressure();
            decimal cloud = GetCloudData();
            decimal visiblity = GetVisiblity();

            return new Data(temperature, wind, humidity, pressure, cloud, visiblity);
        }

        private decimal GetVisiblity()
        {
            decimal text;
            decimal multiplier = 1000;

            this.IsElementDisplayedAfterWaiting(this.Visiblity).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.Visiblity)), out text).Should().BeTrue();

            return (text * multiplier);
        }

        private string GetNumberFromString(string text)
        {
            Regex reg = new Regex(@"\d+");
            return reg.Match(text).Value;
        }

        private decimal GetCloudData()
        {
            decimal text;

            this.IsElementDisplayedAfterWaiting(this.Cloud).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.Cloud)), out text).Should().BeTrue();

            return text;
        }

        private decimal GetPressure()
        {
            decimal text;

            this.IsElementDisplayedAfterWaiting(this.Pressure).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.Pressure)), out text).Should().BeTrue();

            return text;
        }

        private decimal GetHumidity()
        {
            decimal text;

            this.IsElementDisplayedAfterWaiting(this.Humidity).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.Humidity)), out text).Should().BeTrue();

            return text;
        }

        private decimal GetWind()
        {
            decimal text;
            decimal diviser = 3.6m;

            this.IsElementDisplayedAfterWaiting(this.Wind).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.Wind)), out text).Should().BeTrue();

            return (text / diviser);
        }

        private decimal GetTemperature()
        {
            decimal text;

            this.IsElementDisplayedAfterWaiting(this.CurrentTemperature).Should().BeTrue();
            Decimal.TryParse(GetNumberFromString(this.GetTextOfElement(this.CurrentTemperature)), out text).Should().BeTrue();

            return text;
        }
    }
}
