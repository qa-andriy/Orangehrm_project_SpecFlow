using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Orangehrm_project.website
{
    class DashboardPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public const string ACCOUNT_NAME = "//*[@id='account-name']";
        public const string TIME_TAB = "//*[@id='menu_time_viewTimeModule']/a/span[2]";
        public const string ATTENDANCE_TAB = "//*[@id='menu_attendance_Attendance']/a/span[2]";
        public const string EMPLOYEERECORDS_TAB = "//*[@id='menu_attendance_viewAttendanceRecord']/span[2]";

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ACCOUNT_NAME)]
        private IWebElement accountName;

        [FindsBy(How = How.XPath, Using = TIME_TAB)]
        private IWebElement timeTab;

        [FindsBy(How = How.XPath, Using = ATTENDANCE_TAB)]
        private IWebElement attendanceTab;

        [FindsBy(How = How.XPath, Using = EMPLOYEERECORDS_TAB)]
        private IWebElement employeeRecordsTab;

        public String getAccountName()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(ACCOUNT_NAME)));
            return accountName.Text;
        }

        public EmployeeAttendanceRecordsPage navigateToEmployeeRecordsPage()
        {
                wait.Until(ExpectedConditions.ElementToBeClickable(timeTab)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(attendanceTab)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(employeeRecordsTab)).Click();

            return new EmployeeAttendanceRecordsPage(driver);
        }
    }
}
