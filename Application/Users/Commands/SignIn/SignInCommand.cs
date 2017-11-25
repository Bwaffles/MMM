using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Application.Users.Commands.SignIn
{
    public class SignInCommand : ISignInCommand
    {
        public Task<SignInStatus> Execute(ApplicationSignInManager signInManager, SignInModel model)
        {
            return signInManager.PasswordSignInAsync(model.LoginId, model.Password, model.RememberMe, shouldLockout: false);
        }
    }
}