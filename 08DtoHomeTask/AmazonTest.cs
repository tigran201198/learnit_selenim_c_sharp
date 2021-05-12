using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using _08DtoHomeTask.Pages.Impl;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _08DtoHomeTask
{
    public class AmazonTest
    {
        private const string SearchPhrase = "iphone";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckAmazonSearch()
        {
            driver.Navigate().GoToUrl("https://amazon.com/");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.SearchComponent.PerformSearch(SearchPhrase);

            var actualItems = searchResultsPage.SearchResultsItems;
            var expectedItems = searchResultsPage.SearchResultItemsWithText(SearchPhrase);

            Assert.AreEqual(expectedItems, actualItems);
        }

        [OneTimeTearDown]
        public static void TearDownDirver() => driver.Quit();
    }
}