namespace Framework.Test
{
    using System.Diagnostics.Contracts;
    using Framework.Selenium;
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
        public void CompareTemperature()
        {
            this.Driver.Navigate().GoToUrl(this.Config.WebAppUrl);

            HomePage homePage = new HomePage(this.Driver);

            SearchResultPage searchResultPage =  homePage.SearchCity("Bangalore");

            Data WebData = searchResultPage.GetDataFromUi();


        }

        [TestCleanup]
        public void Cleanup()
        {
            this.Driver.Quit();
        }
    }
}
