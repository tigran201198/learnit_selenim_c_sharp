using OpenQA.Selenium;

namespace _06PageObjectHomeTask.Pages.Impl
{
    public class HomePage : WebPage
    {
        private IWebElement SearchInput => FindElement(By.CssSelector("#twotabsearchtextbox"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void PerformSearch(string searchPhrase)
        {
            SearchInput.SendKeys(searchPhrase);
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
