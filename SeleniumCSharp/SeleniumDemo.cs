using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharp.Pages;
using System;

namespace SeleniumCSharp
{
    internal class SeleniumDemo
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            //driver =  new ChromeDriver("C:\\Users\\PC\\source\\repos\\SeleniumCSharp\\SeleniumCSharp\\executables\\chromedriver.exe");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EAWebSiteTest()
        {
            driver.Navigate().GoToUrl("http://eaapp.somee.com");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
            IWebElement txtUserName = driver.FindElement(By.Name("UserName"));
            txtUserName.SendKeys("admin");
            //SelectElement selectEle = new SelectElement(txtUserName);
            //selectEle.SelectByIndex(0);
        }

        [Test]
        public void TestWithPOM()
        {
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //WaitForPageLoaded
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            //POM initialization
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }

        [Test]
        public void Test4()
        {

        }
    }
}
