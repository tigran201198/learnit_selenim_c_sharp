using OpenQA.Selenium;
using System.Collections.Generic;

namespace _06PageObjectHomeTask.Pages
{
    public class WebPage
    {
        private readonly IWebDriver driver;

        protected WebPage(IWebDriver driver) => this.driver = driver;

        protected IWebElement FindElement(By selector) => driver.FindElement(selector);

        protected IList<IWebElement> FindElements(By selector) => driver.FindElements(selector);
    }
}
