<h1> Selenium Mini Project </h1>
In the repository is the implementation of the Selenium, NUnit and Specflow to perform Web testing on this website: https://www.saucedemo.com/
In Visual Studio the versions for each package is listed below

|Package| Version|
|-------|--------:|
|BoDi|1.5.0|
|Cucumber.Messages|6.0.1|
|Gherkin|19.0.3|
|Google.Protobuf|3.7.0|
|NUnit|3.13.1|
|NUnit3TestAdapter|4.0.0|
|Selenium.WebDriver|3.141.0|
|Selenium.WebDriver.ChromeDriver|93.0.4577.6300|
|SpecFlow|3.9.22|
|SpecFlow.Internal.Json|1.0.8|
|SpecFlow.NUnit|3.9.22|
|SpecFlow.Plus.LivingDocPlugin|3.9.57|
|SpecFlow.Tools.MsBuild.Generation|3.9.22|
|System.Configuration.ConfigurationManager|5.0.0|
|System.Security.AccessControl|5.0.0|
|System.Security.Permissions|5.0.0|
|System.Security.Principal.Windows|5.0.0|
|System.ValueTuple|4.4.0|

During the project, I had setup the requiste resources using the Selenium packages to open up the web source and the pages of the web source that would be getting tested.
Then using NUnit to assert that specific things happened i.e, having clicked on a button and then asserting that the website url is what it should be.

Following this, the implementation of Behaviour Driven Development (BDD) uses the Specflow features to make Gherkin Syntax scripts that can then be translated into NUnit tests.
With these tests, the method body would need to be defined so that it can proceed with each statment in the Gherkin script. 

Having implemented one of these feature, it would soon become a problem with the addition of multiple features that all start from the same point, i.e, Signing into the account. 
Such that it would perform the steps from the other feature but then create a new website object which would try and implement the new steps and fail because the objects are missing.
My first correction was rewriting the scripts using syntactically similar language to do the same thing which then turned out to be an inefficient solution however still proving to work.
My correction for that was implementing a super class that would be able to perform the sign in stage, which could be inherited by other steps that add onto the overall testing framework.

One of the things I noticed doing these tests is that the Specflow tests take significantly more time than the pure Selenium tests (which might be due to poor programming on my behalf).
The tests take long because they are being ran in series so using the NUnit 3 packages, I implemented the parallelisable attribute and set it to the fixtures so that each test fixture has one thing running.

Class Diagram:
![Class Diagram](https://github.com/OnlyBiscuitHere/SeleniumPOMWalkthrough/blob/main/img/Screenshot_1.png)
Link to the LivindDoc file:
[LivingDoc Tests](https://github.com/OnlyBiscuitHere/SeleniumPOMWalkthrough/blob/main/SeleniumPOMWalkthrough/bin/Debug/LivingDoc.html)
