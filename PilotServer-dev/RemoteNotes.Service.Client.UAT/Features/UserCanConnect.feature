Feature: UserCanConnect
 	In order to enter the system
	As a trader
	I want to be able to connect to the server

@positive
Scenario: Connect to the service
	Given I try to connect to the service
	Then the result should be connected successfully
