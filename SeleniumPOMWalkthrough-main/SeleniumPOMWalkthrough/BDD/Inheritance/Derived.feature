Feature: Derived
	As a user
	I want to login
	So that I can browse

@Base
Scenario: Sigining in
	Given I want to sign in
	And the following details
	| Email      | password     |
	| standard_user | secret_sauce |
	When I press sign in
	Then I can see the next page