using System;

namespace DataLayer.Entities
{
    public class Inventory : BaseEntity
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ProductCategory { get; set; }

    }
}
