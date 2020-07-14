using System;
namespace BusinessLogic
{
    public class UserModel
    {
        public UserModel(string name, string password)
        {
            UserName = name;
            UserPassword = password;
        }
        public UserModel()
        { 
        }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
