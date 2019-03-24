Feature: Verify number of items in best sellers section
	On home page
	I want to have
	7 items in Best Sellers Category

@BestSellersCategory
Scenario: I want to have 7 items displayed in Best Sellers Category
	Given user opens home page
	And clicks on Best Sellers tab
	Then 7 items are displayed in Best Sellers section