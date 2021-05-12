using OpenQA.Selenium;

namespace _08DtoHomeTask.Components
{
    public class WebComponent
    {
        private readonly IWebElement rootElement;

        protected WebComponent(IWebElement rootElement) => this.rootElement = rootElement;

        protected IWebElement FindElement(By selector) => rootElement.FindElement(selector);

        protected void SendKeys(string text) => rootElement.SendKeys(text); 
    }
}
