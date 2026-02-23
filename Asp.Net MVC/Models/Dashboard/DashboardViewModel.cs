using System.Collections.Generic;

namespace MobileRepairShop.Models.Dashboard
{
    public class DashboardViewModel
    {
        public int TotalCustomers { get; set; }
        public int DevicesInRepair { get; set; }
        public int CompletedRepairs { get; set; }
        public decimal TotalRevenue { get; set; }

        public List<RecentRepair> RecentRepairs { get; set; }
    }
}