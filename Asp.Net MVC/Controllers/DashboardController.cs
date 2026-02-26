using Microsoft.AspNetCore.Mvc;
using Asp.Net_MVC.Models.Dashboard;
using Asp.Net_MVC.Services.Interface;
using MobileRepairShop.Models.Dashboard;

namespace MobileRepairShop.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;

        public DashboardController(IUserService userService)
        {
            _userService = userService;
        }

        // READ
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalCustomers = 5,
                DevicesInRepair = 10,
                CompletedRepairs = 100,
                TotalRevenue = 600000
            };

            ViewBag.ActiveUsers = _userService.GetActiveUsers();
            ViewBag.InactiveUsers = _userService.GetInactiveUsers();

            return View(model);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            _userService.Create(user);
            return RedirectToAction("Index");
        }

        // EDIT
        public IActionResult Edit(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            _userService.Update(user);
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Activate(Guid id)
        {
            _userService.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult Deactivate(Guid id)
        {
            _userService.Deactivate(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViewUser(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }
    }
}