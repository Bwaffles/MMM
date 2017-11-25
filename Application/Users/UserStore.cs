using Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users
{
    public class UserStore : IUserStore<User, int>, IUserPasswordStore<User, int>, IUserEmailStore<User, int>, IUserLockoutStore<User, int>,
        IUserTwoFactorStore<User, int>
    {
        private IUserRepository userRepository;

        public UserStore(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task CreateAsync(User user)
        {
            //TODO: maybe move this into the repository itself
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            userRepository.Add(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            userRepository.Remove(user);

            return Task.FromResult<User>(null);
        }

        public void Dispose()
        {
            //do nothing
        }

        public Task<User> FindByIdAsync(int userId)
        {
            var result = userRepository.FindByID(userId);
            if (result != null)
                return Task.FromResult(result);

            return Task.FromResult<User>(null);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException($"Null or empty argument: {nameof(userName)}");

            var result = userRepository.FindAll().Where(user => user.UserName == userName).ToList();

            //TODO: Should I throw if > 1 user?
            if (result != null && result.Count == 1)
                return Task.FromResult(result[0]);

            return Task.FromResult<User>(null);
        }

        public Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            userRepository.Update(user);

            return Task.FromResult<object>(null);
        }

        #region IUserTwoFactorStore

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        #endregion IUserTwoFactorStore

        #region IUserPasswordStore

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(userRepository.GetPasswordHash(user.Id));
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            bool hasPassword = !string.IsNullOrEmpty(userRepository.GetPasswordHash(user.Id));
            return Task.FromResult(hasPassword);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        #endregion IUserPasswordStore

        #region IUserEmailStore

        public Task<User> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var result = userRepository.FindAll().SingleOrDefault(user => string.Equals(user.Email, email, StringComparison.CurrentCultureIgnoreCase));
            if (result != null)
                return Task.FromResult(result);

            return Task.FromResult<User>(null);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        #endregion IUserEmailStore

        #region IUserLockoutStore

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount++;
            userRepository.Update(user);

            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount = 0;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        #endregion IUserLockoutStore
    }
}