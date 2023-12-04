
Feature: Login
User logs in with valid credentials (username, password)
Home page will load after successful login

Background: 
  Given User will be on the login page

@positive
Scenario Outline: Login with valid credentials
	When User will enter username '<UserName>'
	And  User will enter password '<Password>'
	And  User will click on login button
	Then User will be redirected to home page
Examples:
     | UserName      | Password |
     | abc@gmail.com | 1234     |
     | xyz@gmail.com | 4567     |

@negative
Scenario Outline: Login with invalid credentials
	When User will enter username '<UserName>'
	And  User will enter password '<Password>'
	And  User will click on login button
	Then Error message for password length should be thrown
Examples:
     | UserName      | Password |
     | def@dnne.com  | 444      |
     | xyz@gmail.com | 436      |

@regression
Scenario Outline: Check for Password Hidden Display
	When User will enter password '<Password>'
	And  User will click on show button in the password text box
	Then The password characters should be shown
Examples:
     | Password |
     | 1111     |

@regression
Scenario Outline: Check for Password Show Display
	When User will enter password '<Password>'
	And  User will click on show button in the password text box
	And  User will click on hide button in the password text box
	Then The password characters should not be shown
Examples:
     | Password |
     | 2222     |