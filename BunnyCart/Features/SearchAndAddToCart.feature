Feature: SearchAndAddToCart


@E2E-Search_AddToCart
Scenario: Search 
	Given User will be on the Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'

	Examples: 
	| searchtext | 
	| water      | 