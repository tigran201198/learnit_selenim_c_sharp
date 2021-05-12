using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _02AssertionsHomeTask
{
    public class AssertionsHomeTaskRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://amazon.com/");

            string searchPhrase = "iphone";

            IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            var actualItems = driver.FindElements(By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal"))
                .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
                .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains("invalid search phrase"))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);

            driver.Quit();
        }
    }
}
