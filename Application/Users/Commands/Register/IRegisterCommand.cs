using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Application.Users.Commands.Register
{
    public interface IRegisterCommand
    {
        Task<IdentityResult> Execute(ApplicationUserManager userManager, ApplicationSignInManager signInManager, RegisterModel model);
    }
}