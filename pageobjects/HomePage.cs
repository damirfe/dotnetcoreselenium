using OpenQA.Selenium;
using SimphonyChallenge.Driver;
using System.Collections;
using System.Collections.Generic;

namespace SimphonyChallenge.Pages
{
    public class HomePage
    {
        private static IWebDriver driver = WebDriver.Instance;

        private IWebElement SignInButton =>
            driver.FindElement(By.CssSelector(".header_user_info .login"));

        private IWebElement Popular =>
            driver.FindElement(By.CssSelector("li .homefeatured"));

        private IWebElement BestSeller =>
            driver.FindElement(By.CssSelector("li .blockbestsellers"));

        private IList<IWebElement> PopularProducst =>
            driver.FindElements(By.CssSelector("#homefeatured .product-container"));

        private IList<IWebElement> BestSellerProducst =>
            driver.FindElements(By.CssSelector("#blockbestsellers .product-container"));

        private IWebElement SearchField =>
            driver.FindElement(By.Id("search_query_top"));

        private IWebElement SearchButton =>
            driver.FindElement(By.CssSelector("button.button-search"));

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com");
        }

        public void ClickOnSignInButton()
        {
            SignInButton.Click();
        }

        public void ClickOnPopular()
        {
            Popular.Click();
        }

        public void ClickOnBestSeller()
        {
            BestSeller.Click();
        }

        public void PopulateSearchField(string value)
        {
            SearchField.Clear();
            SearchField.SendKeys(value);
        }

        public void ClickOnSearchButton()
        {
            SearchButton.Click();
        }

        public int ReturnNumberOfPopularProducst() =>
            PopularProducst.Count;

        public int ReturnNumberOfBestSellerProducts() =>
            BestSellerProducst.Count;
    }
}
