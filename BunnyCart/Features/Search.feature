Feature: Search


@Product_Search
Scenario Outline: Search for Products
	Given User will be on the Homepage
	When User will type the '<searchtext>' in the searchbox
	* User clicks on search button
	Then Search results are loaded in the same page with '<searchtext>'

	Examples: 
	| searchtext |
	| water      |
	| java       |
	| hairgrass  |
