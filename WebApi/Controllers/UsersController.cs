using System;
using System.Web.Http;

namespace WebApi.Controllers
{
    using System.Linq;
    using WebApi.Context;

    public class UsersController : ApiController
    {
        private readonly DataBaseContext db = new DataBaseContext();

        [Authorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var transaction = this.db.Database.BeginTransaction())
            {
                try
                {
                    string name = this.db.Database.SqlQuery<string>(@"
                            SELECT Users.Name
                            FROM Users
                            WHERE Users.Id IN (
                            SELECT Users.Id
                            FROM Users 
                            JOIN [Orders] 
                                ON Users.Id = [Orders].UserId 
                            JOIN ItemOrders 
                                ON [Orders].Id = ItemOrders.Order_Id 
                            GROUP BY Users.Id, [Orders].Id 
                            HAVING COUNT(ItemOrders.Item_ItemId) > 3)")
                        .FirstOrDefault<string>();

                    return this.Ok(name);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return this.InternalServerError(e);
                }
            }
        }
    }
}
