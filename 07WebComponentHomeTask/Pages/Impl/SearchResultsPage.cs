using _07WebComponentHomeTask.Components.Impl;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _07WebComponentHomeTask.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private static readonly By SearchResultItemSelector = By.CssSelector("[data-component-type='s-search-result']");

        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> SearchResultsItemsText() => SearchResultsItems
            .Select(item => item.Text)
            .ToList();

        public IList<string> SearchResultsItemsWithText(string searchPhrase) => SearchResultsItems
            .Where(item => item.ContainsSearchPhrase(searchPhrase))
            .Select(item => item.Text)
            .ToList();
    }
}
