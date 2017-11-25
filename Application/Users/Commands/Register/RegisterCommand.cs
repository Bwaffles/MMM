using Domain;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Application.Users.Commands.Register
{
    public class RegisterCommand : IRegisterCommand
    {
        public async Task<IdentityResult> Execute(ApplicationUserManager userManager, ApplicationSignInManager signInManager, RegisterModel model)
        {
            var user = new User { UserName = model.UserName, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
            }

            return result;
        }
    }
}