using dotnetcoreselenium.driver;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Diagnostics;

namespace coretest.Helpers
{
    public abstract class BaseTest
    {
        private Stopwatch _stopwatch = new Stopwatch();
        public TelemetryClient TelemetryClient { get; set; }

        [SetUp]
        public void SetUp()
        {
            TelemetryClient = new TelemetryClient();
            TelemetryClient.Context.Properties.Add("TestClass", TestContext.CurrentContext.Test.ClassName);
            TelemetryClient.Context.Properties.Add("TestMethod", TestContext.CurrentContext.Test.MethodName);
            TelemetryClient.Context.Properties.Add("Browser", WebDriver.CurrentBrowser);
            _stopwatch.Restart();
            WebDriver.Initialize();
        }

        [TearDown]
        public void Cleanup()
        {
            _stopwatch.Stop();
            TelemetryClient.TrackEvent(TestContext.CurrentContext.Result.Outcome.ToString());
            var metric = new MetricTelemetry($"{TestContext.CurrentContext.Test.FullName}.{TestContext.CurrentContext.Test.Name}", _stopwatch.Elapsed.TotalSeconds);
            TelemetryClient.TrackMetric(metric);
            TelemetryClient?.Flush();

            if (!TestCompletedWithoutErrors())
            {
                TakeScreenshot();
            }

            WebDriver.Cleanup();
        }

        private void TakeScreenshot()
        {
            var screenshot = WebDriver.TakeScreenshot(TestContext.CurrentContext.Test.Name);
            if (screenshot != null) TestContext.AddTestAttachment(screenshot);
        }

        public bool TestCompletedWithoutErrors()
        {
            return TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive) ||
                   TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        }
    }
}