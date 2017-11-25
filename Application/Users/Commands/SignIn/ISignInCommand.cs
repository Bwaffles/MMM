using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Application.Users.Commands.SignIn
{
    public interface ISignInCommand
    {
        Task<SignInStatus> Execute(ApplicationSignInManager signInManager, SignInModel model);
    }
}