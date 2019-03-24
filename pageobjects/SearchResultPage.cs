using dotnetcoreselenium.driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace dotnetcoreselenium.pageobjects
{
    public class SearchResultPage
    {
        private IWebDriver driver = WebDriver.Instance;

        private IList<IWebElement> ProductNames =>
            driver.FindElements(By.CssSelector(".right-block .product-name"));

        public bool SaveProductNamesToTxtFile()
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}", $"Dress_{DateTime.UtcNow:yyyyMMMdd}.txt");
                var file = new FileStream(fileName, FileMode.OpenOrCreate);
                var streamWriter = new StreamWriter(file);
                ProductNames.ToList().ForEach(i => streamWriter.WriteLine(i.Text));
                streamWriter.Close();
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
