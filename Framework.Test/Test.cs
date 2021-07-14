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
        ///
        /// </summary>
        public Config Config { get; set; }

        /// <summary>
        ///
        /// </summary>
        IWebDriver Driver { get; set; }

        /// <summary>
        ///
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///
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



        [TestCleanup]
        public void Cleanup()
        {
            this.Driver.Quit();
        }
    }
}
