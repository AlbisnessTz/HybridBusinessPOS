using System;

namespace HybridBusinessPOS.Models
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int QuantityAvailable { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public string WarehouseLocation { get; set; }
        public DateTime LastStockTakeDate { get; set; }
        public DateTime LastRestockDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}