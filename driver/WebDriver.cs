using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace dotnetcoreselenium.driver
{
    public static class WebDriver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                Instance.Manage().Window.Maximize();
            }
            catch (Exception e)
            {

            }
        }

        public static string TakeScreenshot(string testName)
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}", $"{testName}_{DateTime.UtcNow:yyyyMMMdd}.jpg");
                var screenShot = ((ITakesScreenshot)Instance).GetScreenshot();
                screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                return fileName;
            }
            catch (Exception e)
            {
                //Log.Error($"Failed to take screenschot: {e}");
                return null;
            }
        }

        public static void Cleanup()
        {
            Instance?.Quit();
        }
    }
}