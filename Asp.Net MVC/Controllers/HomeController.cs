// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Asp.Net_MVC.Models;
//
// namespace Asp.Net_MVC.Controllers;
//
// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;
//
//     public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     }
//
//     public IActionResult Index()
//     {
//         return View();
//     }
//
//     public IActionResult Privacy()
//     {
//         return View();
//     }
//
//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }

using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_MVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IUserRepo _userRepo;

    public HomeController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public IActionResult Index()
    {
        var vm = new DashboardVm
        {
            TotalUsers = _userRepo.GetTotalUsers(),
            ActiveUsers = _userRepo.GetActiveUsers(),
            InactiveUsers = _userRepo.GetInactiveUsers()
        };

        return View(vm);
    }
    
}