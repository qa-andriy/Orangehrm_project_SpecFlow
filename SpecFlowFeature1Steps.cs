using System;
using TechTalk.SpecFlow;

namespace Orangehrm_project
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"Open https://orangehrm-demo(.*)x\.orangehrmlive\.com")]
        public void GivenOpenHttpsOrangehrm_Demox_Orangehrmlive_Com(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there are no attendance records in the result table")]
        public void GivenThereAreNoAttendanceRecordsInTheResultTable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I type to input with name ""(.*)"" text: ""(.*)""")]
        public void WhenITypeToInputWithNameText(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"type to input with name ""(.*)"" text: ""(.*)""")]
        public void WhenTypeToInputWithNameText(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"press button with text ""(.*)""")]
        public void WhenPressButtonWithText(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click tab element with text ""(.*)""")]
        public void WhenClickTabElementWithText(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"type to input with name ""(.*)"" text ""(.*)""")]
        public void WhenTypeToInputWithNameText(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"select ""(.*)"" date using Date Picker")]
        public void WhenSelectDateUsingDatePicker(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"there are no attendance records in the result table")]
        public void ThenThereAreNoAttendanceRecordsInTheResultTable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the just created attendance record is present in the result table")]
        public void ThenTheJustCreatedAttendanceRecordIsPresentInTheResultTable()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
