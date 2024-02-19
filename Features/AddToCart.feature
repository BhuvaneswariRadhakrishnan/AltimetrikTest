Feature: AddToCart

To verify add to cart functionality

@addToCart
Scenario: Validate add to cart functionality
	Given User has navigated to Amazon website of url "https://www.amazon.in/" 
	And User validate Amazon logo in top left corner
	When User enters "Airpod" in search inputbox
	And User clicks at search button
	And User select first item from list
	And User clicks at addtocart button
	Then User validate added item is present in the shopping cart