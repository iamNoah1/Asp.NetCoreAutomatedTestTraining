using BusinessLogic;
using System;

namespace AutomatedTestTraining
{
    public class Program
    {
        static PasswordValidator validator = new PasswordValidator();

        public static void Main(string[] args)
        {
            Console.WriteLine("Playing around with Password Validation");

            string password = null;
            bool valid = false;

            try
            {
                validator.IsValid(password);
            } catch(Exception e)
            {
                Console.WriteLine($"Error while validating password: {password}, Error: {e.Message}");
            }

            password = "";

            try
            {
                validator.IsValid(password);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while validating password: {password}, Error: {e.Message}");
            }

            password = "1234567";
            valid = validator.IsValid(password);

            Console.WriteLine($"Password {password} is valid: {valid}");

            password = "123456789";
            valid = validator.IsValid(password);

            Console.WriteLine($"Password {password} is valid: {valid}");

            password = "123456789012345691234567890";
            valid = validator.IsValid(password);

            Console.WriteLine($"Password {password} is valid: {valid}");
        }
    }
}
