using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using SMB_SaaS.Core;

namespace SMB_SaaS.BusinessLogic.Elements
{
    public class BaseElement : IWebElement, ILocatable, IWrapsElement
    {
        private IWebDriver _driver = BrowserHelper.GetDriver();
        protected string _name;
        protected By _locator;
        protected IWebElement _element;
        protected ReadOnlyCollection<IWebElement> _elements;

        protected readonly ILog Log = LogManager.GetLogger(typeof(BaseElement));

        public string TagName { get; }

        public string Text { get; }

        public bool Enabled { get; }

        public bool Selected { get; }

        public Point Location { get; }

        public Size Size { get; }

        public bool Displayed => GetElement().Displayed;

        Point IWebElement.Location => GetElement().Location;

        Size IWebElement.Size => GetElement().Size;

        public Point LocationOnScreenOnceScrolledIntoView => GetElement().Location;

        public ICoordinates Coordinates => throw new NotImplementedException();

        public IWebElement WrappedElement => GetElement();

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(IWebElement element, By locator)
        {
            _locator = locator;
            _element = element;
        }

        public void HighLightElement()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserHelper.GetDriver();
            executor.ExecuteScript("arguments[0].style.border='2px solid red'", _driver.FindElement(_locator));
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToDisplay = _driver.FindElement(_locator);
                    HighLightElement();
                    return elementToDisplay.Displayed;
                }
                catch (StaleElementReferenceException staleEx)
                {
                    Log.Debug($"Element reference not found {_locator} : {staleEx.Message}");
                    return false;
                }
                catch (NoSuchElementException noElement)
                {
                    Log.Debug($"Element not found {_locator} : {noElement.Message}");
                    return false;
                }
            });
        }

        public void RightClickOnElement()
        {
            GetElement();
            Actions actions = new Actions(_driver);
            actions.ContextClick(this._element).Perform();
        }

        public void DoubleClickOnElement()
        {
            GetElement();
            Actions actions = new Actions(_driver);
            actions.DoubleClick(this._element).Perform();
        }

        public void DragElementAndDropTo(IWebElement target)
        {
            GetElement();
            Actions actions = new Actions(_driver);
            actions.DragAndDrop(this._element, target).Build().Perform();
        }

        public void Clear()
        {
            _driver.FindElement(_locator).Clear();
        }

        public void Click()
        {
            WaitForIsVisible();
            _driver.FindElement(_locator).Click();
        }

        public void JsClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserHelper.GetDriver();
            executor.ExecuteScript("arguments[0].click();", this.GetElement());
        }

        public void JsClickOnPopup()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserHelper.GetDriver();
            executor.ExecuteScript("arguments[0].checked = true;", this.GetElement());
        }

        public IWebElement GetElement()
        {
            try
            {
                WaitForIsVisible();
                _element = _driver.FindElement(_locator);
            }
            catch (Exception e)
            {
                Log.Debug($"Element not found {_locator} : {e.Message}");
                throw;
            }
            return _element;
        }

        public string GetText()
        {
            WaitForIsVisible();
            GetElement();
            return _element.Text;
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element;
            try
            {
                element = _driver.FindElement(by);
            }
            catch (Exception e)
            {
                Log.Debug($"Element not found {by} : {e.Message}");
                throw;
            }
            return new BaseElement(element, by);
        }

        public BaseElement FindBaseElement(By by)
        {
            IWebElement element;
            try
            {
                element = _driver.FindElement(by);
            }
            catch (Exception e)
            {
                Log.Debug($"Element not found {by} : {e.Message}");
                throw;
            }
            return new BaseElement(element, by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                _elements = _driver.FindElements(by);
            }
            catch (Exception e)
            {
                Log.Debug($"Element not found {by} : {e.Message}");
                throw;
            }
            return _elements;
        }

        public string GetAttribute(string attributeName)
        {
            return _driver.FindElement(_locator).GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _driver.FindElement(_locator).GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return _driver.FindElement(_locator).GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return _driver.FindElement(_locator).GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            _driver.FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            _driver.FindElement(_locator).Submit();
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
