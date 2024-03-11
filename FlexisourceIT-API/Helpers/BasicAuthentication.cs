using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace FlexisourceIT_API.Helpers
{
    public class BasicAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                // Retrieve the request headers
                var headers = context.HttpContext.Request.Headers;

                // Check if the headers contain the required authentication information
                if (!headers.ContainsKey("Username") || !headers.ContainsKey("Password"))
                {
                    // Unauthorized if username or password headers are missing
                    context.Result = new UnauthorizedResult();
                    return;
                }

                // Extract username and password from the headers
                string userName = headers["Username"].FirstOrDefault();
                string password = headers["Password"].FirstOrDefault();

                // Replace this with your user service logic
                var users = new List<User>
                {
                    new User { Username = "admin", Password = "password" }
                };

                var user = users.Find(u => u.Username == userName && u.Password == password);

                if (user != null)
                {
                    // Set the current principal if the user is authenticated
                    context.HttpContext.User = new ClaimsPrincipal(new GenericIdentity(userName));
                }
                else
                {
                    // Unauthorized if the user is not found or authentication fails
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (Exception e)
            {
                // Handle any exceptions and return unauthorized
                context.Result = new UnauthorizedResult();
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
