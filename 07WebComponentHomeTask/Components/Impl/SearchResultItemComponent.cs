using OpenQA.Selenium;

namespace _07WebComponentHomeTask.Components.Impl
{
    public class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector("h2 .a-link-normal");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public bool ContainsSearchPhrase(string searchPhrase)
        {
            var title = FindElement(TitleSelector);
            return ContainsTextIgnoringCase(title.Text, searchPhrase) || 
                ContainsTextIgnoringCase(title.GetAttribute("href"), searchPhrase);
        }

        private bool ContainsTextIgnoringCase(string text, string searchPhrase) =>
            text.ToLower().Contains(searchPhrase);
    }
}
