using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumCSharp
{
    public static class SeleniumCustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }
        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }
        //class static, method static and provide this before IWebElement locator -> apply extensions method in c#
        public static void EnterText(this IWebElement locator, string value)
        {
            locator.SendKeys(value);
        }

        public static void SelectDropdownByText(IWebDriver driver, By locator, string value)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(value);
        }

        public static void MultiSelectElements(IWebDriver driver, By locator, String[] values)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<String> GetAllSelectedLists(IWebDriver driver, By locator)
        {
            List<String> options = new List<String>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
