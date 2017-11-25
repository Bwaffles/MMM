using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Threading.Tasks;

namespace Application.Users
{
    public class ValidateIdentity
    {
        public static Func<CookieValidateIdentityContext, Task> Execute()
        { //since this is used in startup, there is no injection so i just made this static. I don't think ill be unit testing that file anyways
            return SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User, int>(
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                getUserIdCallback: (id) => (int.Parse(id.GetUserId())));
        }
    }
}