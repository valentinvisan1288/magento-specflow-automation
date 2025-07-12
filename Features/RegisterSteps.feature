Feature: RegisterSteps

A short summary of the feature

@TEST-01 @Login @regression @automated
Scenario: An anonymous user is able to register from the main page
	Given an anonymous user has navigated to create an account from the main page
	When the anonymous user submits the mandatory account details
	Then the anonymous user will be redirected to the account page as a registered user