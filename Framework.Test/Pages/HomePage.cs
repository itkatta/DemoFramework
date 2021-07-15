namespace Framework.Test.Pages
{
    using Framework.Selenium;
    using OpenQA.Selenium;

    /// <summary>
    /// Class contains home page mapped objects and interactions.
    /// </summary>
    /// <seealso cref="Framework.Selenium.Base" />
    public class HomePage : Base
    {
        /// <summary>
        /// The search input box.
        /// </summary>
        public By SearchInputBox = By.XPath("//input[@name='query']");


        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// Searches the city.
        /// </summary>
        /// <param name="city">The city.</param>
        internal void SearchCity(string city)
        {
            this.SetText(SearchInputBox, city);
            this.SetText(SearchInputBox, Keys.Enter);
            //return new SearchResultPage(this.Driver);
        }
    }
}
