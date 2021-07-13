namespace Framework.Test
{
    using Framework.Selenium;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    [TestClass]
    public class Test
    {
        IWebDriver Driver { get; set; }

        TestContext  TestContext { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [TestMethod]
        public void TestMethod1()
        {

            this.Driver.Navigate().GoToUrl("https://www.accuweather.com/");
        }
    }
}
