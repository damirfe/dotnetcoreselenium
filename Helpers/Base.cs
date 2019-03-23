using dotnetcoreselenium.driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace dotnetcoreselenium.Helpers
{
    [Binding]
    public class Base
    {

        [BeforeScenario]
        public static void BeforeScenario()
        {
            WebDriver.Initialize();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            if (!TestCompletedWithoutErrors())
            {
                Utilities.SendScreenshotEmail(WebDriver.TakeScreenshot(TestContext.CurrentContext.Test.Name));
            }
            WebDriver.Cleanup();
        }

        public static bool TestCompletedWithoutErrors()
        {
            return TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive) ||
                   TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        }
    }
}
