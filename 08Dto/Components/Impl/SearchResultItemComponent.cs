using _08Dto.Entities;
using OpenQA.Selenium;

namespace _08Dto.Components.Impl
{
    public class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector(".v-align-middle");
        private static readonly By DescriptionSelector = By.CssSelector(".mb-1");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public SearchResultItem ConvertToSearchResultItem() =>
            new SearchResultItem(
                FindElement(TitleSelector).Text.ToLower(),
                FindElement(DescriptionSelector).Text.ToLower()
            );
    }
}
