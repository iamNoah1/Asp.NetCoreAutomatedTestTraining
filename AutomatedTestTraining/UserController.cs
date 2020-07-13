using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;
        private PasswordValidator validator;

        public UserController()
        {
            this.userService = new UserService();
            this.validator = new PasswordValidator();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(JObject userToAdd)
        {
            if (null == userToAdd || "{}" == userToAdd.ToString())
            {
                JObject responseJson = new JObject();
                ObjectResult objectResult;
                responseJson.Add(new JProperty("errorMessage", "no user definition sent"));
                objectResult = new ObjectResult(responseJson);
                objectResult.StatusCode = (int?)HttpStatusCode.BadRequest;

                return objectResult;
            }

            UserModel userModelToAdd = userToAdd.ToObject<UserModel>();
            if (!validator.IsValid(userModelToAdd.UserPassword))
            {
                JObject responseJson = new JObject();
                ObjectResult objectResult;
                responseJson.Add(new JProperty("errorMessage", "password is not valid"));
                objectResult = new ObjectResult(responseJson);
                objectResult.StatusCode = (int?)HttpStatusCode.BadRequest;

                return objectResult;
            }

            try {

                await userService.AddUser(userModelToAdd);
                return new OkResult();

            } catch (Exception e)
            {
                JObject responseJson = new JObject();
                ObjectResult objectResult;
                responseJson.Add(new JProperty("errorMessage", e.Message));
                objectResult = new ObjectResult(responseJson);
                objectResult.StatusCode = (int?)HttpStatusCode.InternalServerError;

                return objectResult;
            }
        }
    }
}
