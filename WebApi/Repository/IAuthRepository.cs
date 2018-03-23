using System.Threading.Tasks;

namespace WebApi.Repository
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebApi.Models;

    /// <summary>
    /// Repository class to support ASP.NET Identity System
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Called to register new user.
        /// </summary>
        /// <param name="userModel">The model to register user.</param>
        /// <returns>The result of IdentityResult </returns>
        Task<IdentityResult> RegisterUser(UserModel userModel);

        /// <summary>
        /// Find user to get credentials.
        /// </summary>
        /// <param name="userName">The name of user.</param>
        /// <param name="password">The password of user</param>
        /// <returns>The result of IdentityUser</returns>
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
