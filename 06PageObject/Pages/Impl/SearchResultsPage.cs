using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _06PageObject.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private IList<IWebElement> SearchResultsItems => FindElements(By.CssSelector(".repo-list-item"));

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> SearchResultsItemsText() => SearchResultsItems
            .Select(item => item.Text.ToLower())
            .ToList();

        public IList<string> SearchResultsItemsWithText(string searchPhrase) => SearchResultsItemsText()
            .Where(itemText => itemText.Contains(searchPhrase))
            .ToList();
    }
}
