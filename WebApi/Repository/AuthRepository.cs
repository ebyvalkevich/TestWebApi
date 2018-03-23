using System;

namespace WebApi.Repository
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebApi.Context;
    using WebApi.Models;

    public class AuthRepository : IAuthRepository, IDisposable
    {
        private readonly AuthContext context;

        private readonly UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            this.context = new AuthContext();
            this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this.context));
        }

        public Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = this.userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await this.userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            this.context.Dispose();
            this.userManager.Dispose();
        }
    }
}