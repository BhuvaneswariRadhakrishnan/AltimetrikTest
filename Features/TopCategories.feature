Feature: TopCategories

To verify logos in Top categories section upon menu selection

@topCategories
Scenario: Verify top categories of Software menu
	Given User has navigated to Amazon website of url "https://www.amazon.in/" 
	And User validate Amazon logo in top left corner
	When User clicks at Hamburger menu
	And User selects option "Mobiles, Computers"
	And User selects sub menu option Software
	Then User validates top categories logos displayed