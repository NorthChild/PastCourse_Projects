Feature: AP_Signin
	

@Login
Scenario: Valid Credentials
	Given I am on signin page
	And I have the following Credentials
	| Email           | Password     |
	| standard_user   | secret_sauce |
	When I enter the credentials
	And I click the sign in button
	Then I should be on the next page

@Login
Scenario: Invalid Password
	Given I am on signin page
	And I have the following Credentials
	| Email         | Password |
	| standard_user | wrong    |
	When I enter the credentials
	And I click the sign in button
	Then I should be given a message saying "Epic sadface: Username and password do not match any user in this service"

@Login
Scenario: No Username
	Given I am on signin page
	And I have the following Credentials
	| Email | Password     |
	|       | secret_sauce |
	When I enter the credentials
	And I click the sign in button
	Then I should be given a message saying "Epic sadface: Username is required"

@Login
Scenario: No fields
	Given I am on signin page
	And I have the following Credentials
	| Email | Password |
	|       |          |
	When I enter the credentials
	And I click the sign in button
	Then I should be given a message saying "Epic sadface: Username is required"

@Login
Scenario: No Password
	Given I am on signin page
	And I have the following Credentials
	| Email           | Password     |
	|   standard_user |  |
	When I enter the credentials
	And I click the sign in button
	Then I should be given a message saying "Epic sadface: Password is required"