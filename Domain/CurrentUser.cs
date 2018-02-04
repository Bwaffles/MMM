using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace Domain
{
    public class CurrentUser : ICurrentUser
    {
        public int UserID { get; private set; }

        public CurrentUser(IIdentity identity)
        {
            UserID = identity.GetUserId<int>();
        }
    }
}