using System;

namespace EntityFrameworkDemo.NetFramework.Entities
{
    public class MyProduct
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }
    }
}