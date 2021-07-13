namespace Framework.Selenium
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Condition = OpenQA.Selenium.Support.UI.ExpectedConditions;

    /// <summary>
    /// base class to handle the page interaction.
    /// </summary>
    public class Base
    {

        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }

        /// <summary>
        /// Constructor for Base class.
        /// </summary>
        /// <param name="driver"></param>
        public Base(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Simple click method.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        protected void Click(By locator) => Driver.FindElement(locator).Click();

        /// <summary>
        /// Sets the text to web element.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <param name="text">Text to be sent to web element.</param>
        protected void SetText(By locator, string text) => LocateElement(locator).SendKeys(text);

        /// <summary>
        /// Gets the text node value form the web element.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>String representation of the value of the text node.</returns>
        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;

        /// <summary>
        /// Gets the value of value attribute of web element.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>String representation of the attribute value.</returns>
        protected string GetValueOfElement(By locator) => LocateElement(locator).GetAttribute("value");

        /// <summary>
        /// Locates the web element on DOM.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>Web element.</returns>
        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        /// <summary>
        /// Waits until web element is visible.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>Web element.</returns>
        protected IWebElement GetElementAfterWaiting(By locator) => Wait.Until(Condition.ElementIsVisible(locator));

        /// <summary>
        /// Checks element is displayed without wait.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>Element is displayed or not with true or false respectively.</returns>
        protected bool IsElementDisplayedImmediately(By locator) => LocateElement(locator).Displayed;

        /// <summary>
        /// Checks element is displayed with wait.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>Element is displayed or not with true or false respectively.</returns>
        protected bool IsElementDisplayedAfterWaiting(By locator) => Wait.Until(Condition.ElementIsVisible(locator)).Displayed;

        /// <summary>
        /// Wait until web element turns invisible.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <returns>Element is displayed or not with true or false respectively.</returns>
        protected bool IsElementDisappearedAfterWaiting(By locator)
        {
            try
            {
                Wait.Until(Condition.InvisibilityOfElementLocated(locator));

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Element is still visible");
            }
        }

        /// <summary>
        /// Waits for elements to be visible and then performs click action.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        protected void ClickOnElementAfterWaiting(By locator) => Wait.Until(Condition.ElementIsVisible(locator)).Click();

        /// <summary>
        /// Waits for elements to be visible and enabled, then performs click action.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        protected void ClickOnClickableElement(By locator) => Wait.Until(Condition.ElementToBeClickable(locator)).Click();

        /// <summary>
        /// waits for element for visible with customized timespan.
        /// </summary>
        /// <param name="locator">Element identification mechanism.</param>
        /// <param name="timeSpan">waits for configured time.</param>
        /// <returns></returns>
        protected IWebElement WaitAndGetElement(By locator, TimeSpan timeSpan)
        {
            Wait.Timeout = timeSpan;
            Wait.Until(Condition.ElementIsVisible(locator));
            return Driver.FindElement(locator);
        }

    }
}
