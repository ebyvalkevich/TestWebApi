using System.Web.Http;

namespace WebApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using WebApi.Models;
    using WebApi.Repository;

    public class AccountController : ApiController
    {
        private readonly AuthRepository repository = null;

        public AccountController()
        {
            this.repository = new AuthRepository();
        }

        public string Get()
        {
            return "Register";
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/account/register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult result = await this.repository.RegisterUser(userModel);

            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        this.ModelState.AddModelError("", error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}
