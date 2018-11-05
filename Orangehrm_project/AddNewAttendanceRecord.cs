using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Orangehrm_project.website;
using System;
using TechTalk.SpecFlow;

namespace Orangehrm_project
{
    [Binding]
    public class AddNewAttendanceRecord
    {
        private IWebDriver driver;

        LoginPage login;
        DashboardPage dashboard;
        EmployeeAttendanceRecordsPage employeeAttendancePage;

        public const string link = "https://orangehrm-demo-6x.orangehrmlive.com";
        public const string USERNAME_TEXT_FIELD = "Admin";
        public const string PASSWORD_TEXT_FIELD = "admin123";
        public const string ACCOUNT_NAME = "Jacqueline White";
        public const string EMPLOYEENAME = "Kevin Mathews";
        public const string NORECORD = "No attendance records to display";
        public const string NEWRECORD = "New record";

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given(@"Navigate to the Login page ""(.*)""")]
        public void GivenNavigateToTheLoginPage(string link)
        {
            login = new LoginPage(driver);
            login.goToLoginPage(link);
        }
        
        [When(@"Login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenLoginWithUsernameAndPasswordOnTheLoginPage(string USERNAME_TEXT_FIELD, string PASSWORD_TEXT_FIELD)
        {
            dashboard = login.goToDashboardPage(USERNAME_TEXT_FIELD, PASSWORD_TEXT_FIELD);
            
            // Verified if correct user logined
            Assert.AreEqual(ACCOUNT_NAME, dashboard.getAccountName(), "Wrong account name on Dashboard page");
        }
        
        [When(@"Navigate to Time -> Attendance -> Employee Records")]
        public void WhenNavigateToTime_Attendance_EmployeeRecords()
        {
            employeeAttendancePage = dashboard.navigateToEmployeeRecordsPage();
        }
        
        [When(@"Open view for emplotee ""(.*)"" with appropriate date using Date Picker")]
        public void WhenOpenViewForEmploteeWithAppropriateDateUsingDatePicker(string EMPLOYEENAME)
        {
            employeeAttendancePage.viewEmployee(EMPLOYEENAME);
        }

        [Then(@"There are no attendance records in the result table")]
        public void ThenThereAreNoAttendanceRecordsInTheResultTable()
        {
            // Verified count of rows on Result table after click button View
            Assert.AreEqual(1, employeeAttendancePage.iRowsCount, "More than one row present in the ResultTable");
            // Verified if result in teble correct
            Assert.AreEqual(EMPLOYEENAME, employeeAttendancePage.employeeNameResultViewMode.Text, "Don't found Employee with name 'Kevin Mathews' in ResultTable");
            Assert.AreEqual(NORECORD, employeeAttendancePage.puchInResultViewMode.Text, "Don't found 'No attendance records to display' in ResultTable");
        }

        [When(@"Add a new attendance record")]
        public void WhenAddANewAttendanceRecord()
        {
            employeeAttendancePage.AddNewAttendanceRecord(NEWRECORD);
        }
                
        [Then(@"The just created attendance record is present in the result table")]
        public void ThenTheJustCreatedAttendanceRecordIsPresentInTheResultTable()
        {
            // Verified count of rows on Result table after click button View
            Assert.AreEqual(1, employeeAttendancePage.iRowsCount, "More than one row present in the ResultTable");
            // Verified if result in teble correct
            Assert.AreEqual(EMPLOYEENAME, employeeAttendancePage.employeeNameResultAddMode.Text, "Don't found Employee with name 'Kevin Mathews' in ResultTable");
            Assert.AreEqual(NEWRECORD, employeeAttendancePage.puchInResultAddMode.Text, "Don't found 'New record' in ResultTable");
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            driver.Close();
        }
    }
}
