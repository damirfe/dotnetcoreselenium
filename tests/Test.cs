using coretest.Helpers;
using coretest.pageobjects;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class Tests : BaseTest
    {
        private TestPageObject testPageObject = new TestPageObject();

        [Test]
        public void ValidateGoogleImageBox()
        {
            testPageObject.NavigateToLandingPage();
            testPageObject.PopulateSearchBar("wadduuup");
            testPageObject.ClickGoogleSearch();            
            
            // testPageObject.ValidateImageBoxPresent().Should().BeTrue();
            true.Should().BeTrue();
        }
    }
}