using BusinessLogic;
using System;
using Xunit;

namespace UnitTests
{
    public class PasswordValidatorTester
    {
        [Fact]
        public void trivialTestCase()
        {
            Assert.True(true);
        }

        [Fact]
        public void PasswordValidatorShouldThrowExpectionIfPasswordIsNull()
        {
            PasswordValidator unitUnderTest = new PasswordValidator();
            string passwordToCheck = null;

            Action action = () => unitUnderTest.IsValid(passwordToCheck);

            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void PasswordValidatorShouldThrowExpectionIfPasswordIsEmpty()
        {
            PasswordValidator unitUnderTest = new PasswordValidator();
            string passwordToCheck = "";

            Action action = () => unitUnderTest.IsValid(passwordToCheck);

            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void PasswordValidatorShouldReturnFalseIfPasswordLengthIsLessThan8()
        {
            PasswordValidator unitUnderTest = new PasswordValidator();
            string passwordToCheck = "1234567";

            bool result = unitUnderTest.IsValid(passwordToCheck);

            Assert.False(result);
        }

        [Fact]
        public void PasswordValidatorShouldReturnFalseIfPasswordLengthIsMoreThan20()
        {
            PasswordValidator unitUnderTest = new PasswordValidator();
            string passwordToCheck = "1234567891234567890123";

            bool result = unitUnderTest.IsValid(passwordToCheck);

            Assert.False(result);
        }

        [Fact]
        public void PasswordValidatorShouldReturnTrueIfPasswordLengthIsBetween8And20()
        {
            PasswordValidator unitUnderTest = new PasswordValidator();
            string passwordToCheck = "1234567891234";

            bool result = unitUnderTest.IsValid(passwordToCheck);

            Assert.True(result);
        }
    }

}
