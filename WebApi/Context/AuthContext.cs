namespace WebApi.Context
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("DefaultConnection")
        {

        }
    }
}