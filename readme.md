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