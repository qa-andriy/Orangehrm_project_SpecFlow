using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Orangehrm_project.website
{
    public class EmployeeAttendanceRecordsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public int iRowsCount;

        public const string ATTENDANCE_EMPLOYEE_FIELD = "//input[@id='attendance_employeeName_empName']";
        public const string ATTENDANCE_DATE_FIELD = "//input[@id='attendance_date']";
        public const string ATTENDANCE_DATE_IN_DATE_PICKER_TODAY_ITEM = "//button[@class='btn-flat picker__today']";
        public const string VIEW_BUTTON = "//*[@id='btView']";
        public const string EMPLOYEE_NAME_RESULT_VIEW_MODE = "//table[@id='resultTable']//tr[@class='dataRaw'][1]/td[1]";
        public const string EMPLOYEE_NAME_RESULT_ADD_MODE = "//table[@id='resultTable']//tr[@class='dataRaw'][1]/td[2]";
        public const string PUNCH_IN_RESULT_VIEW_MODE = "//table[@id='resultTable']//tr[@class='dataRaw'][1]/td[2]";
        public const string PUNCH_IN_RESULT_ADD_MODE = "//table[@id='resultTable']//tr[@class='dataRaw'][1]/td[4]";
        public const string ADD_NEW_ATTENDANCE_RECORD_BUTTON = "//*[@id='btnAdd']";
        public const string ATTENDANCE_NOTE_FIELD = "//*[@id='attendance_note']";
        public const string PUNCH_IN_BUTTON = "//*[@id='btnPunch']";
        public const string EMPLOYEE_DROPDOWN_LIST = "//*[@class='ac_results']/ul";
        public const string EMPLOYEE_RESULT_TABLE = "//table[@id='resultTable']//tr[@class='dataRaw']";

        public EmployeeAttendanceRecordsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ATTENDANCE_EMPLOYEE_FIELD)]
        public IWebElement attendanceEmployeeNameField;

        [FindsBy(How = How.XPath, Using = ATTENDANCE_DATE_FIELD)]
        public IWebElement attendanceDateField;

        [FindsBy(How = How.XPath, Using = ATTENDANCE_DATE_IN_DATE_PICKER_TODAY_ITEM)]
        public IWebElement attendanceDateTodayInDatePicker;

        [FindsBy(How = How.XPath, Using = VIEW_BUTTON)]
        public IWebElement viewButton;

        [FindsBy(How = How.XPath, Using = EMPLOYEE_NAME_RESULT_VIEW_MODE)]
        public IWebElement employeeNameResultViewMode;

        [FindsBy(How = How.XPath, Using = EMPLOYEE_NAME_RESULT_ADD_MODE)]
        public IWebElement employeeNameResultAddMode;

        [FindsBy(How = How.XPath, Using = PUNCH_IN_RESULT_VIEW_MODE)]
        public IWebElement puchInResultViewMode;

        [FindsBy(How = How.XPath, Using = PUNCH_IN_RESULT_ADD_MODE)]
        public IWebElement puchInResultAddMode;

        [FindsBy(How = How.XPath, Using = ADD_NEW_ATTENDANCE_RECORD_BUTTON)]
        public IWebElement addNewAttendanceRecordButton;

        [FindsBy(How = How.XPath, Using = ATTENDANCE_NOTE_FIELD)]
        public IWebElement attendanceNoteField;

        [FindsBy(How = How.XPath, Using = PUNCH_IN_BUTTON)]
        public IWebElement punchInButton;


        // select employee from list and click button View
        public void viewEmployee(string employeeName)
        {
            // Switch to frame "noncoreIframe"
            driver.SwitchTo().Frame("noncoreIframe");

            // Typing EmployeeName to attendanceEmployeeNameField
            wait.Until(ExpectedConditions.ElementToBeClickable(attendanceEmployeeNameField)).Click();
            attendanceEmployeeNameField.Clear();
            attendanceEmployeeNameField.Click();
            attendanceEmployeeNameField.SendKeys(employeeName);

            // Select EmployeeName from Employee dropDownList
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(EMPLOYEE_DROPDOWN_LIST)));
            String xpath = string.Format(".//li[contains(text(),'{0}')]", employeeName);
            IWebElement drop = driver.FindElement(By.XPath(EMPLOYEE_DROPDOWN_LIST)).FindElement(By.XPath(xpath));
            drop.Click();

            // Waiting for elements (attendanceDateField and attendanceDateTodayItem) will be loaded and clickable
            wait.Until(ExpectedConditions.ElementToBeClickable(attendanceDateField)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(attendanceDateTodayInDatePicker)).Click();

            // Click on hidden button "View"
            clickHiddenButton(driver, viewButton);
            Thread.Sleep(1000);

            // Waiting for elements from table results (columns - Employee Name and Punch In) will be loaded
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(EMPLOYEE_NAME_RESULT_VIEW_MODE)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PUNCH_IN_RESULT_VIEW_MODE)));

            // Calculating Employee names counts in result table 
             iRowsCount = driver.FindElements(By.XPath(EMPLOYEE_RESULT_TABLE)).Count;
    }

        public void AddNewAttendanceRecord(string attendanceNote)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(addNewAttendanceRecordButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(attendanceNoteField)).Click();
            attendanceNoteField.Clear();
            attendanceNoteField.SendKeys(attendanceNote);

            wait.Until(ExpectedConditions.ElementExists(By.XPath(PUNCH_IN_BUTTON)));

            // Click on hidden button "PunchIn"
            clickHiddenButton(driver, punchInButton);
            Thread.Sleep(1000);

            // Waiting for elements from table results (columns - Employee Name and Punch In) will be loaded after adding new record
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(EMPLOYEE_NAME_RESULT_ADD_MODE)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PUNCH_IN_RESULT_ADD_MODE)));
        }

        public static Object clickHiddenButton(IWebDriver driver, IWebElement element)
          {
                       return (Object)((IJavaScriptExecutor)driver).ExecuteScript(
                           "arguments[0].click();", element);
        }
    }
}




