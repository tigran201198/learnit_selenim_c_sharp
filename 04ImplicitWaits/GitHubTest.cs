using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _04ImplicitWaits
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");

            var searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            var actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(item => item.Text.ToLower())
                .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();

            Assert.True(IsElementVisible(By.CssSelector("[title='invalid title']")));

            Assert.AreEqual(expectedItems, actualItems);
        }

        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            driver.Quit();
        }

        private bool IsElementVisible(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return driver.FindElement(selector).Displayed;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }
    }
}
