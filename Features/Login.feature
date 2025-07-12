Feature: Login

A short summary of the feature

@TEST-01 @Login @regression @automated
Scenario: An anonymous user is able to register from the main page
	Given an anonymous user has navigated to create an account from the main page
	When the anonymous user submits the mandatory account details
	Then the anonymous user will be redirected to the account page as a registered user

@TEST-02 @Login @regression @automated
Scenario: A registered user is able to log in from the main page  
  Given a registered user has navigated to the login page from the main page  
  When the registered user submits valid login credentials  
  Then the registered user will be redirected to the account page

@TEST-03 @Login @regression @automated
Scenario: An anonymous user cannot log in with an invalid account
  Given an anonymous user has navigated to the login page from the main page  
  When the anonymous user submits invalid login credentials  
  Then the anonymous user will remain on the login page and see an error message