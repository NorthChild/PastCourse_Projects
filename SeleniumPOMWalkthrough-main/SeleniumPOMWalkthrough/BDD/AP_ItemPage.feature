Feature: AP_ItemPage
	As a User 
	I want to add items to a cart
	So that I may make a transaction

@ViewingAnItemCart @HappyPath
Scenario: User wants to go item page
	Given I have logged in
	And I am on the public inventory page
	When click on the first item
	Then I am taken to the item page

@AddingAnItemCart @HappyPath
Scenario: User wants to add an item to the cart
	Given I have logged in
	And I am on the public inventory page
	When click on the first item
	And click add to cart
	Then cart inventory is incremented