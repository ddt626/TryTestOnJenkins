Feature: TestDBWork
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add a budget
	When add budget Year "2017-01" Amount 100
	Then the result should be a budget
