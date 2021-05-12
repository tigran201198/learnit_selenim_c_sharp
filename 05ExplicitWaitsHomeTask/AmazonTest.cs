using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _05ExplicitWaitsHomeTask
{
    public class AmazonTest
    {
        private const string SearchPhrase = "iphone";

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
        public void CheckAmazonSearch()
        {
            driver.Navigate().GoToUrl("https://amazon.com");

            var searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            var actualItems = driver.FindElements(By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal"))
               .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
               .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();

            SwitchImplicitWaitOff();
            Assert.True(IsElementVisibleWithExplicitWait(By.CssSelector("#invalid")));

            Assert.AreEqual(expectedItems, actualItems);
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();


        private static bool IsElementVisibleWithExplicitWait(By selector)
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

        private static bool IsElementVisible(By selector)
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

        private static void SwitchImplicitWaitOff() => 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
