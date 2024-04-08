Feature: Search

@smoke
Scenario: 01 User search existing term by clicking on search button
	Given User opened the home page
	When User enter Printed Summer Dress in search bar
	And User click on search button
	And User can see message 7 results have been found.
	Then User verify there is 7 items shown

@smoke
Scenario: 02 User search existing term by clicking on suggestion from dropdown
	Given User opened the home page
	When User enter Sleeve in search bar
	And User choose Blouses term from dropdown
	And User can see Blouse title
	Then User can see picture of only one item


@smoke
Scenario: 03 User search non-existing term
	Given User opened the home page
	When User enter Jeans in search bar
	And User click on search button
	And User can see message 0 results have been found.
	Then User verify alert message No results were found for your search "Jeans"
	
@smoke
Scenario: 04 User search without entering term
	Given User opened the home page
	When User click on search button
	And User can see message 0 results have been found.
	Then User verify alert message Please enter a search keyword


