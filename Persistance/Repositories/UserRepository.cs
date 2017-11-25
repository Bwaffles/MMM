using Application.Users;
using Domain;

namespace Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository() : base("[User]")
        {
        }

        public string GetPasswordHash(int userId)
        {
            var user = FindByID(userId);
            if (user == null)
                return null;

            return user.PasswordHash;
        }
    }
}