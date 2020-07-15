# Automated Test Training 
This is a project that can be used for training regarding unit and integration testing of ASP .Net Core Applications. 

## Solution Anatomy 

### BusinessLogic
The `BusinessLogic` Project contains the elements that we want to test.

## How to use 
The project has different branches that represent the steps you can go through, building a little application and add tests while the app grows. Also this readme file will grow with each step and contain the respective instructions. Each following step will contain solutions for the tasks of the step before. So just start by checking out `step0` branch. 

### Step 0 
At this point the solution only contains the `BusinessLogic` Project which is a just a Console Application. There is Password Validator class that can be used to validate a given password. Check out the Main Entry to see an example. 

Tasks:
* Have a look at the `PasswordValidator` class
* In the Main Entry Point, play around by using the `PasswordValidator` class in order to get familiar with its functiontality 

### Step 1
Now that you know how to use the `PasswordValidator` Class, it's time to start with Unit Tests. Have a look at the main entry point. Now there are some example usages of `PasswordValidator` class. 

Tasks:
* Create a new Project named `UnitTests`
* Add the needed dependencies for unit testing to the `UnitTests` project. We will use XUnit here
* Add a Class named `PasswordValidatorTester`
* Add a Test Method which contains a trivial test (Assert.True(true)) just to see if Unit Testing was bootstrapped correctly
* Run the Unit Tests 

### Step 2 
At this point everything should be prepared for writing some test cases for the `PasswordValidator` class.

Tasks: 
* Write Tests cases for the happy path
* Write Tests cases for the bad path
* (optional) Write Test cases for the edge cases
* Run your tests :) 

### Step 3 
You should have written some test cases by now. Anyway, I have also done that. Check the `PasswordValidatorTester` Class and compare it to the test cases you have written. Admittedly those testing examples were pretty simple, right? Now let's have a look at more real life use cases.  

Tasks:
* Create a `UserController` with an endpoint that allows to add a user (simple json body containing name and password)
* Take into account validating the body and returning respective http response codes (200, 400, 500)
* Create a `UserService` to handle the persistence of a user. Let's use MongoDB for this training, if you don't know how to use MongoDB inside a .Net application have a look at (this example project)[https://github.com/iamNoah1/azure-functions-mongodb].
* Run your API. Therefore you will need to change the Program.cs and add a Startup.cs file. You know how to do that, right?

### Step 4
Ok, let's see. We have an API that can persist a user. Have a look at the solution of step 3 and compare it to your solution. It should be pretty similar to one another. Now let's get our hands dirty and write some unit tests for the controller. Note: in order to properly connect to MongoDB you will need to set the envirionment variable `MONGO_DB_CONNECTION_STRING`to the actual connection string of a running MongoDB.

Tasks:
* Create a class named `UserControllerTester` in the `UnitTests` project.
* Think about the testing scope. What do we want to test and what do want to mock?!
* Think about the possible test cases of the controllers method to add a user. Write them down as XUnit test cases.
* Implement your test cases. You will have to mock stuff, the recommendation is to use Moq as mocking framework.

### Step 5
I hope you had no trouble with the last tasks. It was a little bit tricky to test the controller regarding the dependencies to the service and the validator right? Check my solution and compare it yours. At this point we are prett much done with unit testing. You may think about unit testing the service class, but it does not contain any logic. It pretty stupid and acts only as a proxy for persistence. The last tasks were the most tricky ones, so for the last step we will do something really ease. We make use of the test coverage and refactor some parts of the code without having to fear of breaking anything. 

Tasks:
* In the UserController there is some code duplication regarding error responses. Remove that code duplication. 
