using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using Xunit;

namespace UnitTests
{
    public class UserControllerTester
    {
        public UserControllerTester()
        {
        }

        [Fact]
        public async void AddUserShouldReturn400IfBodyIsEmpty()
        {
            UserController unitUnderTest = new UserController(null, null);

            ObjectResult result = (ObjectResult) await unitUnderTest.AddUser(new JObject());
            JObject responseBody = (JObject)result.Value;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("no user definition sent", responseBody["errorMessage"]);
        }

        [Fact]
        public async void AddUserShouldReturn400IfThereIsNoBody()
        {
            UserController unitUnderTest = new UserController(null, null);

            ObjectResult result = (ObjectResult)await unitUnderTest.AddUser(null);
            JObject responseBody = (JObject)result.Value;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("no user definition sent", responseBody["errorMessage"]);
        }

        [Fact]
        public async void AddUserShouldReturn400IfPasswordIsInvalid()
        {
            var passwordValidatorMock = new Mock<PasswordValidator>();
            passwordValidatorMock.Setup(validator => validator.IsValid(It.IsAny<String>())).Returns(false);

            UserController unitUnderTest = new UserController(null, passwordValidatorMock.Object);

            UserModel userToAdd = new UserModel("noah", "pwd");

            ObjectResult result = (ObjectResult)await unitUnderTest.AddUser(JObject.FromObject(userToAdd));
            JObject responseBody = (JObject)result.Value;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("password is not valid", responseBody["errorMessage"]);
        }

        [Fact]
        public async void AddUserShouldReturn200IfUserWasAddedSuccessfully()
        {
            var passwordValidatorMock = new Mock<PasswordValidator>();
            passwordValidatorMock.Setup(validator => validator.IsValid(It.IsAny<String>())).Returns(true);

            var userServiceMock = new Mock<UserService>();
            userServiceMock.Setup(service => service.AddUser(It.IsAny<UserModel>())).Verifiable();

            UserController unitUnderTest = new UserController(userServiceMock.Object, passwordValidatorMock.Object);

            UserModel userToAdd = new UserModel("noah", "supersavepwd");

            OkResult result = (OkResult)await unitUnderTest.AddUser(JObject.FromObject(userToAdd));
            
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            userServiceMock.Verify();
        }

        [Fact]
        public async void AddUserShouldReturn500IfAddingUserFailed()
        {
            var passwordValidatorMock = new Mock<PasswordValidator>();
            passwordValidatorMock.Setup(validator => validator.IsValid(It.IsAny<String>())).Returns(true);

            var userServiceMock = new Mock<UserService>();
            userServiceMock.Setup(service => service.AddUser(It.IsAny<UserModel>())).Throws(new Exception("error while adding user"));

            UserController unitUnderTest = new UserController(userServiceMock.Object, passwordValidatorMock.Object);

            UserModel userToAdd = new UserModel("noah", "supersavepwd");

            ObjectResult result = (ObjectResult)await unitUnderTest.AddUser(JObject.FromObject(userToAdd));
            JObject responseBody = (JObject)result.Value;

            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.Equal("error while adding user", responseBody["errorMessage"]);
        }
    }
}
