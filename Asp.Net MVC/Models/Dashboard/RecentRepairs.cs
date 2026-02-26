using System;

namespace MobileRepairShop.Models.Dashboard
{
    public class RecentRepair
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Auto-generate GUID
        public string CustomerName { get; set; }
        public string DeviceModel { get; set; }
        public string Issue { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
    }
}