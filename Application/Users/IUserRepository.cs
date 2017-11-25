using Domain;

namespace Application.Users
{
    public interface IUserRepository : IRepository<User>
    {
        string GetPasswordHash(int userId);
    }
}