Feature: SearchAndAddToCart

@E2E-Search_And_Add_To_Cart
Scenario Outline: 1 Search for products
	Given User will be on the Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'
	Then The heading should have '<searchtext>'
	* Title should have '<searchtext>'
Examples: 
	| searchtext | 
	| water      | 

@E2E-Search_And_Add_To_Cart
Scenario Outline: 2 Select a particular product
	Given Search page is loaded
	When User selects a '<productno>'
	Then Product page is loaded
Examples: 
	| productno | 
	| 1         | 