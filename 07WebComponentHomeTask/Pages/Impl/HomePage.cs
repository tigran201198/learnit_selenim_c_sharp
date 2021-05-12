using _07WebComponentHomeTask.Components.Impl;
using OpenQA.Selenium;

namespace _07WebComponentHomeTask.Pages.Impl
{
    public class HomePage : WebPage
    {
        private static readonly By SearchComponentSelector = By.CssSelector("#twotabsearchtextbox");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
