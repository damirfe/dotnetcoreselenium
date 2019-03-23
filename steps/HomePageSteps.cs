using dotnetcoreselenium.Helpers;
using dotnetcoreselenium.pageobjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace dotnetcoreselenium.steps
{
    [Binding]
    public class HomePageSteps : Base
    {
        HomePage homePage = new HomePage();
        SearchResultPage searchResultsPage = new SearchResultPage();

        [Given(@"user opens home page")]
        public void GivenUserOpensSignInPage()
        {
            homePage.NavigateToHomePage();
        }

        [Given(@"user navigates to sign in page")]
        public void GivenUserNavigatesToSignInPage()
        {
            homePage.ClickOnSignInButton();
        }

        [Given(@"clicks on Popular tab")]
        public void GivenClicksOnPopularTab()
        {
            homePage.ClickOnPopular();
        }

        [Then(@"(.*) items are displayed in Popular section")]
        public void ThenItemsAreDisplayedOnPage(int p0)
        {
            Assert.AreEqual(7, homePage.ReturnNumberOfPopularProducst());
        }

        [Given(@"clicks on Best Sellers tab")]
        public void GivenClicksOnBestSellersTab()
        {
            homePage.ClickOnBestSeller();
        }

        [Then(@"(.*) items are displayed in Best Sellers section")]
        public void ThenItemsAreDisplayedInBestSellersSection(int p0)
        {
            Assert.AreEqual(7, homePage.ReturnNumberOfBestSellerProducts());
        }

        [Given(@"search by keyword '(.*)'")]
        public void GivenSearchByKeyword(string p0)
        {
            homePage.PopulateSearchField(TestConstants.PrintedDresses);

        }

        [Given(@"clicks on search button")]
        public void GivenClicksOnSearchButton()
        {
            homePage.ClickOnSearchButton();
        }

        [Then(@"the results are saved into txt file")]
        public void ThenTheResultsAreSavedIntoTxtFile()
        {
            Assert.True(searchResultsPage.SaveProductNamesToTxtFile());
        }

        [Given(@"test fais")]
        public void GivenTestFais()
        {
            Assert.True(false);
        }


    }
}
