using OpenQA.Selenium;

namespace SeleniumCSharp.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement TxtUser => driver.FindElement(By.Id("UserName"));
        IWebElement TxtPwd => driver.FindElement(By.Id("Password"));
        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        public void ClickLogin()
        {
            LoginLink.ClickElement();
        }

        public void Login(string username, string password)
        {
            //SeleniumCustomMethods.EnterText(TxtUser, username);
            //SeleniumCustomMethods.EnterText(TxtPwd, password);
            //SeleniumCustomMethods.SubmitElement(BtnLogin);
            TxtUser.EnterText(username);
            TxtPwd.EnterText(password);
            BtnLogin.SubmitElement();
        }

    }
}
