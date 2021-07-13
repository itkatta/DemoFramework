namespace Framework.Test.Pages
{
    using Framework.Selenium;
    using OpenQA.Selenium;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Framework.Selenium.Base" />
    public class HomePage : Base
    {
        private const string HomePageUrl = @"https://www.accuweather.com/";


        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {

        }


        public bool verifyHomePage => this.Driver.Url.Equals(HomePageUrl);
    }
}
