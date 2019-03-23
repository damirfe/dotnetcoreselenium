Feature: VerifySearch
	I want to verify search by
	searching for specific items
	And validate those items

@mytag
Scenario: Verify search
	Given user opens home page
	And search by keyword 'Printed Dresses'
	And clicks on search button
	Then the results are saved into txt file
