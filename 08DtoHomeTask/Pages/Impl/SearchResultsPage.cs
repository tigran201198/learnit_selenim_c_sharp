using OpenQA.Selenium;
using _08DtoHomeTask.Components.Impl;
using _08DtoHomeTask.Entities;
using System.Collections.Generic;
using System.Linq;

namespace _08DtoHomeTask.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private static readonly By SearchResultItemSelector = By.CssSelector("[data-component-type='s-search-result']");

        private IList<SearchResultItemComponent> SearchResultItemComponents => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<SearchResultItem> SearchResultsItems => SearchResultItemComponents
            .Select(component => component.ConvertToSearchResultItem())
            .ToList();

        public IList<SearchResultItem> SearchResultItemsWithText(string text) => SearchResultsItems
            .Where(item => item.Title.Contains(text) || item.HrefAttributeValue.Contains(text))
            .ToList();
    }
}
