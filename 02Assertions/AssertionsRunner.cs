using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _02Assertions
{
    public class AssertionsRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://github.com/");

            string searchPhrase = "selenium";

            IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(item => item.Text.ToLower())
                .ToList();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains("invalid search phrase"))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);

            driver.Quit();
        }
    }
}
