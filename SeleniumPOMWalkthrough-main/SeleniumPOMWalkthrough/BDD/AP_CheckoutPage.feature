Feature: AP_Checkout
	As a User 
	I want to checkout items
	So that I can complete a transaction

@UserAddsAllItemsToCart @HappyPath
Scenario: User adds all items to cart
	Given I have signed in
	And I am on the catalog
	When I add all items to the cart
	Then Cart inventory should be 6

@UserGoesToCheckout @HappyPath
Scenario: User goes to the checkout page
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	When I go to cart all items should be in cart
	Then I can checkout

@UserAddsDetails @HappyPath
Scenario: User enters personal details
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	| me        | me       | SG8      |
	Then I can continue

@UserAddsDetails @SadPath
Scenario: User enters personal details - All Empty Fields
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	|       |        |       |
	And press continue
	Then I should be given an error message saying "Error: First Name is required"

@UserAddsDetails @SadPath
Scenario: User enters personal details - Username is filled rest are Empty Fields
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	| me      |        |       |
	And press continue
	Then I should be given an error message saying "Error: Last Name is required"

@UserAddsDetails @SadPath
Scenario: User enters personal details - Everything but postcode filled in
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	| me      | me       |       |
	And press continue
	Then I should be given an error message saying "Error: Postal Code is required"

@UserViewsOrderDetails @HappyPath
Scenario: User views total order
	Given I have signed in
	And I am on the catalog 
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	| me        | me       | SG8      |
	And press continue
	Then I should be taken to the order page

@UserViewsOrderDetails @HappyPath
Scenario: User completes order
	Given I have signed in
	And I am on the catalog
	And I have added all items to the cart
	And I am on the checkout page
	When I enter my personal details
	| firstname | lastname | postcode |
	| me        | me       | SG8      |
	And press continue
	And I press finish
	Then I have checked out
