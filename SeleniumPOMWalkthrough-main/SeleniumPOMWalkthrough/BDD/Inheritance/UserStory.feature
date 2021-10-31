Feature: UserStory
	As a User 
	I want to be able to checkout items
	So that I can complete a transaction

@Checkout @HappyPath
Scenario: User Checkouts all items
	Given I want to sign in
	And the following details
	| Email      | password     |
	| standard_user | secret_sauce |
	When I press sign in 
	And I add all items to the basket
	And I go to basket
	And I enter personal details for order
	| firstname | lastname | postcode |
	| me        | me       | SG8      |
	And I press continue
	And I press the finish button
	Then I have checkedout