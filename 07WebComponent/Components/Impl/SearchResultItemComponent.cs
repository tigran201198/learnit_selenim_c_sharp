using OpenQA.Selenium;

namespace _07WebComponent.Components.Impl
{
    public class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector(".v-align-middle");
        private static readonly By DescriptionSelector = By.CssSelector(".mb-1");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public bool ContainsSearchPhrase(string searchPhrase) => 
            ContainsTextIgnoringCase(searchPhrase, TitleSelector) || ContainsTextIgnoringCase(searchPhrase, DescriptionSelector);

        private bool ContainsTextIgnoringCase(string searchPhrase, By selector) => 
            FindElement(selector).Text.ToLower().Contains(searchPhrase);
    }
}
