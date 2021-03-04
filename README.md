A. Framework Description:

This is a page object model framework created using Selenium, Specflow & C#. The framework is seggregated into various parts for better understandablibity & easier maintainability.

Scenarios Folder: Conatains specflow file with the BDD user scenarios.

Steps Folder: This contains the step definitions class file which has the logic for the user scenarios mentioned in the specflow file. This folder also has the RestAPIHelper class which contains the logic for requestions & responses for the API calls.

Data Folder: This contains a class file which has logic for allowing the framework to read data from a json file rather than hard coding the test data into the step definition. It also contains a json file which stores all the test data that will be used by the application under test.

B. Running Tests:

1. Download the Project in your local machine
2. Open "Testing.sln" file using Visual Studio IDE
3. Build the solution
4. Use test explorer to run the tests
