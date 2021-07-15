namespace Framework.Selenium
{
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// Class to maintain different browsers capabilities.
    /// </summary>
    public class WebDrivercapabilities
    {
        /// <summary>
        /// Default capabilities for Chrome driver.
        /// </summary>
        /// <returns>Chrome options object.</returns>
        public static ChromeOptions DefaultChromeCapabilities()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("start-maximized");

            return options;
        }
    }
}
