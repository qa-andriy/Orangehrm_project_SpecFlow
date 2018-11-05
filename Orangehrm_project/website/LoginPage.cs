using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_project.website
{
    class LoginPage
    {
        private IWebDriver driver;

        public const string USERNAME_FIELD = "//*[@id='txtUsername']";
        public const string PASSWORD_FIELD = "//*[@id='txtPassword']";
        public const string LOGIN_BUTTON = "//*[@id='btnLogin']";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = USERNAME_FIELD)]
        private IWebElement userNameField;

        [FindsBy(How = How.XPath, Using = PASSWORD_FIELD)]
        private IWebElement passField;

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        private IWebElement loginButton;

        internal void goToPage()
        {
            throw new NotImplementedException();
        }

        // go to website
        public void goToLoginPage(String link)
        {
            driver.Navigate().GoToUrl(link);
        }
        
        // Login to website with login and password
        public DashboardPage goToDashboardPage(string userName, string password)
        {
            userNameField.Clear();
            userNameField.SendKeys(userName);
            passField.Clear();
            passField.SendKeys(password);
            loginButton.Click();
            return new DashboardPage(driver);
        }


    }
}
