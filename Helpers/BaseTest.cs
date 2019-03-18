using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace coretest.Helpers
{
    public class BaseTest
    {
        public static IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}