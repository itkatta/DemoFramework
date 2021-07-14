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

        public By SearchInputBox = By.XPath("//input[@name='query']");


        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {

        }


        public bool verifyHomePage => this.Driver.Url.Equals(HomePageUrl);

        internal void SearchCity(string city)
        {
            this.SetText(SearchInputBox, city);
            this.SetText(SearchInputBox, Keys.Enter);
            //return new SearchResultPage(this.Driver);
        }
    }
}
