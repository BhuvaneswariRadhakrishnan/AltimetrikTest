Feature: SearchItems
	To validate search functionality in Amazon

@homepage
Scenario: Validate home page logo
	Given User has navigated to Amazon website of url "https://www.amazon.in/"
	Then User validate Amazon logo in top left corner


#negative test case in last input	
@search 
Scenario Outline: Validate search functionality
	When User clears search box
	And User enters <ProductName> in search inputbox
	And User clicks at search button
	Then User validates <ExpResult> in search result info bar
	Examples:
	| ProductName | ExpResult   |
	| "Toy"       | "Toy"       |
	| "Book"      | "Book"      |
	| "Laptop"    | "Laptopz"   |