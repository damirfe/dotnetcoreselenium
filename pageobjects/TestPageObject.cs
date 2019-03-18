using dotnetcoreselenium.driver;
using OpenQA.Selenium;

namespace coretest.pageobjects
{
    public class TestPageObject
    {
        private static IWebDriver driver = WebDriver.Instance;

        private IWebElement SearchBar
        {
            get
            {
                return driver.FindElement(By.CssSelector(".gLFyf.gsfi"));
            }
        }

        private IWebElement ImageBox
        {
            get
            {
                return driver.FindElement(By.Id("imagebox_bigimages"));
            }
        }

        private IWebElement GoogleSearch
        {
            get
            {
                return driver.FindElement(By.CssSelector(@".FPdoLc.VlcLAe input"));
            }
        }

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