using OpenQA.Selenium;
using _08DtoHomeTask.Entities;

namespace _08DtoHomeTask.Components.Impl
{
    public class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector("h2 .a-link-normal");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public SearchResultItem ConvertToSearchResultItem() => 
            new SearchResultItem(
                FindElement(TitleSelector).Text,
                FindElement(TitleSelector).GetAttribute("href")
            );
    }
}
