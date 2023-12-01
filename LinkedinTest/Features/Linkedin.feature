
Feature: Login
User logs in with valid credentials (username, password)
Home page will load after successful login

Background: 
  Given User will be on the login page

@positive
Scenario: Login with Valid Credentials
	When User will enter username
	And User will enter password
	And User will click on login button
	Then User will be redirected to Homepage

@negative
Scenario: Login with Invalid Credentials
	When User will enter username
	And User will enter password
	And User will click on login button
	Then Error message for Password Length should be thrown

@regression
Scenario: Check for Password Hidden Display
	When User will enter password
	And User will click on Show link in the password input box
	Then the password characters should be shown

@regression
Scenario: Check for Password Show Display
	When User will enter password
	And User will click on Show link in the password input box
	And User will click on Hide link in the password input box
	Then the password characters should be *

