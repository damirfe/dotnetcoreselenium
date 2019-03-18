using System.IO;
using System.Reflection;
using System.Threading;
using coretest.Helpers;
using coretest.pageobjects;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Tests : BaseTest
    {
        private TestPageObject testPageObject = new TestPageObject(driver);

        [Test]
        public void ValidateGoogleImageBox()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize(); 
            testPageObject.PopulateSearchBar("wadduuup");
            testPageObject.ClickGoogleSearch();            
            
            testPageObject.ValidateImageBoxPresent().Should().BeTrue();
        }
    }
}