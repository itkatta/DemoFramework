namespace Framework.Test
{
    using System;
    using System.Diagnostics.Contracts;
    using FluentAssertions;
    using Framework.Selenium;
    using Framework.Test.API;
    using Framework.Test.Models;
    using Framework.Test.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    [TestClass]
    public class Test
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config { get; set; }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Initializes this test instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            Config = Config.Instance(this.TestContext);
            this.Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [TestMethod]
        public void CalculateTemperatueVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Temperature, ApiData.Temperature);

            double min = Double.Parse(this.Config.TempMin);
            double max = Double.Parse(this.Config.TempMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }

        [TestMethod]
        public void CalculateWindSpeedVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Wind, ApiData.Wind);

            double min = Double.Parse(this.Config.WindMin);
            double max = Double.Parse(this.Config.WindMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }

        [TestMethod]
        public void CalculatePressureVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Pressure, ApiData.Pressure);

            double min = Double.Parse(this.Config.PressureMin);
            double max = Double.Parse(this.Config.PressureMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }

        [TestMethod]
        public void CalculateCloudVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Cloud, ApiData.Cloud);

            double min = Double.Parse(this.Config.CloudMin);
            double max = Double.Parse(this.Config.CloudMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }
        [TestMethod]
        public void CalculateVisibilityVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Visibility, ApiData.Visibility);

            double min = Double.Parse(this.Config.VisibilityMin);
            double max = Double.Parse(this.Config.VisibilityMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }
        [TestMethod]
        public void CalculateHumidityVaianceForValidRange()
        {
            string city = "Bangalore";

            // web
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);
            homePage.SearchCity(city);

            SearchResultPage searchResultPage = new SearchResultPage(this.Driver);

            Data WebData = searchResultPage.GetDataFromUi();

            Driver.Quit();

            // Api

            ApiRequest apiRequest = new ApiRequest(this.Config);

            ApiResponse apiResponse = apiRequest.WithCity(city).WithUnit(Units.metric).Build().Execute();

            Data ApiData = new Data(
                apiResponse.Main.Temp,
                apiResponse.Wind.Speed,
                apiResponse.Main.Humidity,
                apiResponse.Main.Pressure,
                apiResponse.Clouds.All,
                apiResponse.Visibility
                );

            double variance = Helper.CalculateVariance(WebData.Humidity, ApiData.Humidity);

            double min = Double.Parse(this.Config.HumidityMin);
            double max = Double.Parse(this.Config.HumidityMax);

            Math.Round(variance, 2).Should().BeInRange(min, max);

        }

        /// <summary>
        /// Cleanups this test instance.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this.Driver.Quit();
        }
    }
}
