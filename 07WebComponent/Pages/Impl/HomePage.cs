using _07WebComponent.Components.Impl;
using OpenQA.Selenium;

namespace _07WebComponent.Pages.Impl
{
    public class HomePage : WebPage
    {
        private static readonly By SearchComponentSelector = By.CssSelector("[name='q']");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
