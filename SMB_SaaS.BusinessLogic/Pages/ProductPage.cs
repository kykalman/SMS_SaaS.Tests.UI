using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SMB_SaaS.Core;
using SMB_SaaS.BusinessLogic.Elements;
using SMB_SaaS.Core.Utilities;
using SMB_SaaS.Core.Models;

namespace SMB_SaaS.BusinessLogic.Pages
{
    public class ProductPage: BasePage
    {
        private readonly By AddProductToCartLocator = By.XPath("//span[contains(text(),'Add to Cart')]");
        private readonly By GoToCartLocator = By.XPath("//span[contains(text(), 'Go to cart')]");
        private BaseElement AddProductToCartButton=> new BaseElement(AddProductToCartLocator);
        private BaseElement GoToCartButton => new BaseElement(GoToCartLocator);

        public ProductPage(string title)
        {
            AssertPageIsOpened(title);
        }
        protected void AssertPageIsOpened(string locator)
        {
            var title = JsGetTitle();
            if (title.Contains(locator)) return;
            else throw new Exception();
        }
        public void AddProductToCart()
        {
            AddProductToCartButton.Click();
        }
        public void GoToGart()
        {
            GoToCartButton.Click();
        }
    }
}
