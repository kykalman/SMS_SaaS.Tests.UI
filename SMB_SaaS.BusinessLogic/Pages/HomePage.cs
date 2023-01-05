using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SMB_SaaS.Core;
using SMB_SaaS.BusinessLogic.Elements;

namespace SMB_SaaS.BusinessLogic.Pages
{

    public class HomePage: BasePage
    {
        public HomePage(string title)
        {
            AssertPageIsOpened(title);
        }
        public void OpenProductPage(string product)
        {
            var productCart = new BaseElement(By.XPath($"//span[contains(text(),'{product}')]"));
            productCart.Click();
        }
        
        public void OpenCatalog()
        {

        }
        
        public void SelectCategoryPage()
        {

        }
        protected void AssertPageIsOpened(string locator)
        {
            var title = JsGetTitle();
            if (title == locator) return;
            else throw new Exception();
        }
    };
}
