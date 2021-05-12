using _08Dto.Pages.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _08Dto
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.SearchComponent.PerformSearch(SearchPhrase);

            var actualItems = searchResultsPage.SearchResultItems();
            var expectedItems = searchResultsPage.SearchResultsItemsWithText(SearchPhrase);

            Assert.AreEqual(expectedItems, actualItems);
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }
}
