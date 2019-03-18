using dotnetcoreselenium.driver;
using OpenQA.Selenium;

namespace coretest.pageobjects
{
    public class TestPageObject
    {
        private static IWebDriver driver = WebDriver.Instance;

        private IWebElement SearchBar =>
            driver.FindElement(By.CssSelector(".gLFyf.gsfi"));

        private IWebElement ImageBox =>
            driver.FindElement(By.Id("imagebox_bigimages"));


        private IWebElement GoogleSearch =>
            driver.FindElement(By.CssSelector(@".FPdoLc.VlcLAe input"));


        public void NavigateToLandingPage()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        public void PopulateSearchBar(string text)
        {
            SearchBar.Clear();
            SearchBar.SendKeys(text);
        }

        public void ClickGoogleSearch()
        {
            GoogleSearch.Click();
        }

        public bool ValidateImageBoxPresent()
        {
            return ImageBox.Displayed && ImageBox.Enabled;
        }
    }
}