Feature: SpecFlowFeature1
	Try to add new record for special employee

@mytag
Scenario: Add new attendance record
	Given Navigate to the Login page "https://orangehrm-demo-6x.orangehrmlive.com"
	When Login with Username 'Admin' and Password 'admin123' on the Login Page
	And Navigate to Time -> Attendance -> Employee Records
	And Open view for emplotee "Kevin Mathews" with appropriate date using Date Picker
	Then There are no attendance records in the result table
	When Add a new attendance record
	Then The just created attendance record is present in the result table
