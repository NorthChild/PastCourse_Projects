using System;
using TechTalk.SpecFlow;
using CalculatorProject;
using NUnit.Framework;
using System.Linq;

namespace CalculatorBDD
{
    [Binding]
    public class CalculatorSteps
    {

        private Calculator _calculator;
        private int _result;
        private Exception _divideByZeroException;


        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }
        
        [Given(@"I enter (.*) adn (.*) into the calculator")]
        public void GivenIEnterAdnIntoTheCalculator(int a, int b)
        {
            _calculator.Num1 = a;
            _calculator.Num2 = b;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch (DivideByZeroException e)
            {
                _divideByZeroException = e;
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }


        // divide by zero
        [Then(@"the operation should throw an error")]
        public void ThenTheOperationShouldThrowAnError()
        {
            Assert.That(_divideByZeroException, Is.TypeOf<DivideByZeroException>());
        }

        // iterate through list
        [Given(@"i enter numbers below to a list")]
        public void GivenIEnterNumbersBelowToAList(Table table)
        {
            string[] array = table.Rows.Select(r => r[0]).ToArray();
            int[] numsArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                numsArray[i] = Int32.Parse(array[i]);
            }

            _calculator.Nums = numsArray;
        }

        [When(@"i iterate through the list to add all the even numbers")]
        public void WhenIIterateThroughTheListToAddAllTheEvenNumbers()
        {

            var result = 0;

            foreach (var i in _calculator.Nums)
            {
                if (i % 2 == 0)
                {
                    result += i;
                }
            }

            _result = result;
        }


    }
}
