using MaksimApp.Core.Models;
using MaxsimApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaxsimApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser()
        //    {
        //        FullName = "Fatime Kerimli",
        //        UserName = "Kerimliif"
        //    };
        //    await _userManager.CreateAsync(user, "Fatimedi@123");
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return Ok();
        //}

        //public async Task<IActionResult> CreateRoles()
        //{

        //    await _roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name="Admin"
        //    });
        //    await _roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Moderator"
        //    });
        //    await _roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Member"
        //    });
        //    return Ok();
        //}

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVm adminLoginVm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(adminLoginVm.UserName);
            if(user == null)
            {
                ModelState.AddModelError("","Username veya password yanlisdir!!!");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, adminLoginVm.Password, true);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Username/Email ve ya Password yanlisdir");
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
