Feature: Verify number of items in popular section
	On home page
	I want to have
	7 items in Popular Category

@PopularCategory
Scenario: I want to have 7 items displayed in Popular Category
	Given user opens home page
	And clicks on Popular tab
	Then 7 items are displayed in Popular section