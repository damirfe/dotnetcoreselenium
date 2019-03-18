using OpenQA.Selenium;

namespace coretest.pageobjects
{
    public class TestPageObject
    {
        private readonly IWebDriver driver;

        public TestPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement SearchBar
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".gLFyf.gsfi"));
            }
        }

        private IWebElement ImageBox
        {
            get
            {
                return this.driver.FindElement(By.Id("imagebox_bigimages"));
            }
        }

        private IWebElement GoogleSearch
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(@".FPdoLc.VlcLAe input[value=""Google Search""]"));
            }
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