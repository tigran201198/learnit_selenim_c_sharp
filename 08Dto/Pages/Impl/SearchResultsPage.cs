using _08Dto.Components.Impl;
using _08Dto.Entities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _08Dto.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private static readonly By SearchResultItemSelector = By.CssSelector(".repo-list-item");

        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<SearchResultItem> SearchResultItems() => SearchResultsItems
            .Select(item => item.ConvertToSearchResultItem())
            .ToList();

        public IList<SearchResultItem> SearchResultsItemsWithText(string searchPhrase) => SearchResultItems()
            .Where(item => item.Description.Contains(searchPhrase) || item.Title.Contains(searchPhrase))
            .ToList();
    }
}
