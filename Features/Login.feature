Feature: Login

@Demo-1 @Login @API @automated
Scenario: An anynomous user can login with a registered account in the Todoist app
	Given an anonymous user has login credentials to an existing Todoist account
	When the anonymous user sends a login request
	Then the anonymous user will receive a 200 response code