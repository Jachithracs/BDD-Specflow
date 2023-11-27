Feature: GoogleSearch

To perform search operations on Google home page

@tag1
Scenario: To perform search with Google search button
	Given Google Homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the Google Search Button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"

Scenario: To perform search with IMFL button
	Given Google Homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the IMFL button
	Then the results should be redirected to a new page with title "HP Laptops"
