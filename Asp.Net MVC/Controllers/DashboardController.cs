using Microsoft.AspNetCore.Mvc;
using MobileRepairShop.Models.Dashboard;
using System.Collections.Generic;

namespace MobileRepairShop.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalCustomers = 50,
                DevicesInRepair = 10,
                CompletedRepairs = 100,
                TotalRevenue = 600000,

                RecentRepairs = new List<RecentRepair>
                {
                    new RecentRepair { CustomerName="Ram Bahadur", DeviceModel="iPhone 13", Issue="Screen Replacement", Status="Completed", Cost=15000 },
                    new RecentRepair { CustomerName="Dhan Bahadur", DeviceModel="Samsung S22", Issue="Battery Issue", Status="In Progress", Cost=12000 },
                    new RecentRepair { CustomerName="Sita kumari", DeviceModel="iPhone 12", Issue="Water Damage", Status="Pending", Cost=20000 }
                }
            };

            return View(model);
        }
    }
}