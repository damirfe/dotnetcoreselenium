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
        public static string CurrentBrowser => Environment.GetEnvironmentVariable("TestMachine") ?? Browsers.Chrome;


        public static void Initialize()
        {
            Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //switch (CurrentBrowser)
            //{
            //    case Browsers.Chrome:
            //        Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //        break;
            //    case Browsers.Firefox:
            //        Instance = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //        break;
            //    //case Browsers.Edge:
            //    //    Instance = new EdgeDriver();
            //    //    break;
            //    //case Browsers.IE11:
            //    //    Instance = new InternetExplorerDriver();
            //    //    break;
            //    default:
            //        Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //        //throw new Exception("Test machine environmental variable has not been set. Browser is unknow.");
            //}
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