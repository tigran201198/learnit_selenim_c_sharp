using OpenQA.Selenium;

namespace _07WebComponent.Components.Impl
{
    public class SearchComponent : WebComponent
    {
        public SearchComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public void PerformSearch(string searchPhrase)
        {
            SendKeys(searchPhrase);
            SendKeys(Keys.Enter);
        }
    }
}
