using System.Collections.Generic;

namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tech
    {
        public class Company
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }

            public virtual ICollection<User> Users { get; set; }

            // For migration
            public string Address { get; set; }
        }

        public class User
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }

            public int? CompanyId { get; set; }

            public virtual Company Company { get; set; }

            public virtual ICollection<Order> Orders { get; set; }

        }

        public class Order
        {
            [Key]
            public int Id { get; set; }

            public int? UserId { get; set; }

            public virtual User Users { get; set; }

            public virtual ICollection<Item> Items { get; set; }
        }

        public class Item
        {
            [Key]
            public int ItemId { get; set; }

            public string Name { get; set; }

            public virtual ICollection<Order> Orders { get; set; }
        }
    }
}