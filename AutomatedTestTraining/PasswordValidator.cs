using System;

namespace BusinessLogic
{
    public class PasswordValidator
    {
        virtual public bool IsValid(string passwordToCheck)
        {
            bool result = true;

            if (String.IsNullOrEmpty(passwordToCheck))
            {
                throw new Exception("password is null or empty");
            }
            else
            {
                if (passwordToCheck.Length < 8)
                {
                    result = false;
                }
                else if (passwordToCheck.Length > 20)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
