namespace Framework.Selenium
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;

    /// <summary>
    /// Factory class responsible for creating different drivers.
    /// </summary>
    public class WebDriverFactory
    {
        /// <summary>
        /// Creates the different browser drivers.
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        public IWebDriver Create(BrowserType browserType)
        {
            try
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        return new ChromeDriver(WebDrivercapabilities.DefaultChromeCapabilities());
                    default:
                        throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"{nameof(browserType)} is not supported");
                }
            }
            catch (Exception ex)
            { }
            return null;

        }
    }
}
