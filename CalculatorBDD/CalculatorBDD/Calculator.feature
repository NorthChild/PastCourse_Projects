Feature: Calculator
	Simple calculator for adding two numbers

@mytag
Scenario: Addition
	Given I have a calculator
	And I enter 5 adn 2 into the calculator
	When I press add
	Then the result should be 7


@mytag
Scenario: Subtraction
	Given I have a calculator
	And I enter <input1> adn <input2> into the calculator
	When I press subtract
	Then the result should be <result>


Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 0      |
	| 0      | 1      | -1     |
	| 1000   | 1      | 999    |


@mytag
Scenario: Multiply
	Given I have a calculator
	And I enter <input1> adn <input2> into the calculator
	When I press multiply
	Then the result should be <result>


Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 1      |
	| 2      | 3      | 6      |
	| -17    | 5      | -85    |
	| -0     | 5      | 0      |


@mytag
Scenario: Divide
	Given I have a calculator
	And I enter <input1> adn <input2> into the calculator
	When I press divide
	Then the result should be <result>


Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 1      |
	| 8      | 2      | 4      |
	


# Divide by Zero Exception
@mytag
Scenario: DivideByZero
	Given I have a calculator
	And I enter 5 adn 0 into the calculator
	When I press divide
	Then the operation should throw an error



@mytag
Scenario: SumOfNumbersDivisibleByTwo
	Given I have a calculator
	And i enter numbers below to a list 
	| nums |
	|1     |
	|2     |
	|3     |
	|4     |
	|5     |
	When i iterate through the list to add all the even numbers
	Then the result should be 6