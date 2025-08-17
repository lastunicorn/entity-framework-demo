using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.NetFramework.Entities
{
    [Table("Orders")]
    internal class CustomerOrder
    {
        public Guid Id { get; set; }

        [Column("Date")]
        public DateTime OrderDate { get; set; }

        [Column("Product")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public MyProduct Product { get; set; }
    }
}
