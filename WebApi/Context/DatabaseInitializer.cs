using System.Collections.Generic;

namespace WebApi.Context
{
    using System.Data.Entity;
    using WebApi.Models;

    public class DatabaseInitializer : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            base.Seed(context);

            var company1 = new Tech.Company()
            {
                Id = 1,
                Name = "Tech"
            };
            var company2 = new Tech.Company()
            {
                Id = 2,
                Name = "Sym"
            };
            var company3 = new Tech.Company()
            {
                Id = 3,
                Name = "Micr"
            };

            var user1 = new Tech.User()
            {
                Id = 1,
                Name = "Tom",
                Company = company1,
                CompanyId = 1
            };
            var user2 = new Tech.User()
            {
                Id = 2,
                Name = "Roy",
                Company = company2,
                CompanyId = 2
            };
            var user3 = new Tech.User()
            {
                Id = 3,
                Name = "Todd",
                Company = company3,
                CompanyId = 3
            };

            var order1 = new Tech.Order() { Id = 1, Users = user1, UserId = 1 };
            var order2 = new Tech.Order() { Id = 2, Users = user2, UserId = 2 };
            var order3 = new Tech.Order() { Id = 3, Users = user3, UserId = 3 };
            var order4 = new Tech.Order() { Id = 4, Users = user3, UserId = 3 };

            var item1 = new Tech.Item() { ItemId = 1, Name = "t", Orders = new List<Tech.Order>() { order1 } };
            var item2 = new Tech.Item() { ItemId = 2, Name = "u", Orders = new List<Tech.Order>() { order1, order2 } };
            var item3 = new Tech.Item() { ItemId = 3, Name = "i", Orders = new List<Tech.Order>() { order1, order3 } };
            var item4 = new Tech.Item() { ItemId = 4, Name = "o", Orders = new List<Tech.Order>() { order1, order4 } };



            context.Company.Add(company1);
            context.Company.Add(company2);
            context.Company.Add(company3);

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            context.Order.Add(order1);
            context.Order.Add(order2);
            context.Order.Add(order3);
            context.Order.Add(order4);

            context.Item.Add(item1);
            context.Item.Add(item2);
            context.Item.Add(item3);
            context.Item.Add(item4);

            context.SaveChanges();
        }
    }
}