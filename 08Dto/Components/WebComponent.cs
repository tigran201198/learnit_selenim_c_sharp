using OpenQA.Selenium;

namespace _08Dto.Components
{
    public class WebComponent
    {
        private readonly IWebElement rootElement;

        protected WebComponent(IWebElement rootElement) => this.rootElement = rootElement;

        protected IWebElement FindElement(By selector) => rootElement.FindElement(selector);

        public string Text => rootElement.Text;

        public void SendKeys(string text) => rootElement.SendKeys(text);
    }
}
