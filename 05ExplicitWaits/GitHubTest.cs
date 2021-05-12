using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _05ExplicitWaits
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;
        private static WebDriverWait wait;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [OneTimeSetUp]
        public static void SetUpWait() => 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

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

            Assert.True(IsElementVisibleWithExplicitWait(By.CssSelector("[title='invalid']")));

            Assert.AreEqual(expectedItems, actualItems);
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();

        private bool IsElementVisibleWithExplicitWait(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return wait.Until(d => driver.FindElement(selector).Displayed);
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        private bool IsElementVisible(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return driver.FindElement(selector).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        private static void SwitchOffImplicitWait() => 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
