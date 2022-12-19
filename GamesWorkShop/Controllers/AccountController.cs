using AutoMapper;
using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        public AccountController(IMapper mapper, IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                vm.Role = "Admin";
                var result = await _accountService.RegistrationAsync(vm);

                TempData["msg"] = result.Description;
            }
            return RedirectToAction(nameof(Registration));
        }

        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var result = await _accountService.LoginAsync(vm);
            if (result.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction(nameof(ProductController.Index), "Product");
            }
            else
            {
                TempData["msg"] = result.Description;
                return RedirectToAction(nameof(Login));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(UserLoginInfoViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _accountService.ChangePassword(vm);
        //        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        //        {
        //            return Json(new { description = response.Description });
        //        }
        //    }
        //    return StatusCode(StatusCodes.Status400BadRequest);
        //}

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
