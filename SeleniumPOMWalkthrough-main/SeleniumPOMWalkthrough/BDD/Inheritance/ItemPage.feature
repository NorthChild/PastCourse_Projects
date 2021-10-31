Feature: ItemPage
	As a User 
	I want to add items to a cart
	So that I may make a transaction

@Item @HappyPath
Scenario: User wants to go an item page
	Given I want to sign in
	And the following details
	| Email      | password     |
	| standard_user | secret_sauce |
	When I press sign in
	And I click on the first item
	Then I should be on the first item page

@Item @HappyPath
Scenario: User wants to add item to the cart
	Given I want to sign in
	And the following details
	| Email      | password     |
	| standard_user | secret_sauce |
	When I press sign in
	And I click on the first item
	Then I should be able to add item to the cart
	And The cart should increment