using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharp.Pages;
using System;
using System.Collections.Generic;

namespace SeleniumCSharp
{
    [TestFixture("admin", "password")] //2 param chỗ này ứng với 2 biến nằm trong constructor
    public class NUnitDemo
    {

        private IWebDriver _driver;
        private readonly string username;
        private readonly string password;

        public NUnitDemo(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
            _driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        [Category("smoke")]
        public void TestWithPOM()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(username, password);
        }

        [Test]
        [TestCase("chrome", "30")] //2params này ứng với 2 đối số trong hàm test
        public void TestBrowserVersion(string browser, string version)
        {
            Console.WriteLine($"The browser is {browser} with version {version}");
        }


        [Test]
        [TestCaseSource(nameof(Login))]
        public void TestCaseSourveDataDriven(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginModel.username, loginModel.password);
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                username = "admin",
                password = "password",
            };
            yield return new LoginModel()
            {
                username = "admin1",
                password = "password1",
            };
        }
    }
}
