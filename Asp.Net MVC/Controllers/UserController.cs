using Asp.Net_MVC.Dtos;
using Asp.Net_MVC.Enums;
using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.Services.Interface;
using Asp.Net_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_MVC.Controllers;

// [Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserRepo _userRepo;

    public UserController(IUserService userService, IUserRepo userRepo)
    {
        _userService = userService;
        _userRepo = userRepo;
    }
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var users = await _userRepo.GetQueryable().ToListAsync();

        var vm = users.Select(x => new UserReportVm
        {
            Id = x.Id,
            Name = x.Name,
            Username = x.Username,
            Email = x.Email,
            Address = x.Address,
            ContactNo = x.ContactNo,
            Status = x.Status.ToString(),
            IsActive = x.Status == StatusEnum.Active
        }).ToList();

        return View(vm);
    }
   
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(AddUserVm vm)
    {
        if (!vm.Password.Equals(vm.ConfirmPassword))
            throw new Exception("Passwords do not match");

        var dto = new NewUserDto
        {
            Name = vm.Name,
            ContactNo = vm.ContactNo,
            UserName = vm.Username,
            Email = vm.Email,
            Address = vm.Address,
            Password = vm.Password
        };

        _userService.AddUser(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var user = await _userRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception("User not found");

        var vm = new EditUserVm
        {
            UserId = user.Id,
            Name = user.Name,
            ContactNo = user.ContactNo,
            UserName = user.Username,
            Email = user.Email,
            Address = user.Address
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditUserVm vm)
    {
        var user = await _userRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.Id == vm.UserId);

        if (user == null)
            throw new Exception("User not found");

        var dto = new UserEditDto
        {
            Name = vm.Name,
            ContactNo = vm.ContactNo,
            UserName = vm.UserName,
            Email = vm.Email,
            Address = vm.Address
        };

        _userService.EditUser(user, dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(long id)
    {
        var user = await _userRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception("User not found");

        _userService.RemoveUser(user);

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Activate(long id)
    {
        var user = await _userRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception("User not found");

        _userService.ActivateUser(user);

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> PermanentDelete(long id)
    {
        var user = await _userRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new Exception("User not found");

        _userService.PermanentDelete(user);

        return RedirectToAction("Index");
    }

}