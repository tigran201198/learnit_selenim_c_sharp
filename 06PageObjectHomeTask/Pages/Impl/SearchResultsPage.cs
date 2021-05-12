using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _06PageObjectHomeTask.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private IList<IWebElement> SearchResultsItems => FindElements(By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal"));

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> SearchResultsItemsText() => SearchResultsItems
            .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
            .ToList();

        public IList<string> SearchResultsItemsWithText(string searchPhrase) => SearchResultsItemsText()
            .Where(item => item.Contains(searchPhrase))
            .ToList();
    }
}
