using Asp.Net_MVC.Services.Interface;
using Asp.Net_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddUserVm vm)
    {
        await _service.CreateUserAsync(vm);
        return RedirectToAction("UserReport");
    }

    public async Task<IActionResult> UserReport()
    {
        var users = await _service.GetUsersAsync();
        return View(users);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditUserVm vm)
    {
        await _service.EditUserAsync(vm);
        return RedirectToAction("UserReport");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _service.RemoveUserAsync(id);
        return RedirectToAction("UserReport");
    }
    
    public async Task<IActionResult> Activate(int id)
    {
        await _service.ActivateUserAsync(id);
        return RedirectToAction("UserReport");
    }
    
    public async Task<IActionResult> DeletePermanent(int id)
    {
        await _service.DeleteUserPermanentAsync(id);
        return RedirectToAction("UserReport");
    }
}