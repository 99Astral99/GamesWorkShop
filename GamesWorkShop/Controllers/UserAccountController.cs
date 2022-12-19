using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.View.ProfileModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesWorkshop.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountProfleService;
        private readonly UserManager<User> _userManager;
        public UserAccountController(IUserAccountService userAccountProfleService, UserManager<User> userManager)
        {
            _userAccountProfleService = userAccountProfleService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);

            var userId = _userManager.GetUserId(HttpContext.User);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var userName = _userManager.GetUserName(HttpContext.User);
            var response = await _userAccountProfleService.GetProfile(userId, userEmail, userName);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserAccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var response = await _userAccountProfleService.Save(vm);
                //return RedirectToAction(nameof(UserAccountController.Detail), "UserAccount");
                if (response.StatusCode == Domain.Enums.StatusCode.OK)
                    return Json(new { description = response.Description });
            }
            //await _userAccountProfleService.Save(vm);
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePasswordDetail()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _userAccountProfleService.GetLogin(userEmail);
            if (response != null)
                return View(response.Data);
            return View();
        }















        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(UserLoginInfoViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _userAccountProfleService.ChangePassword(vm);
        //        if(response.StatusCode == Domain.Enums.StatusCode.OK)
        //        {
        //            return Json(new { description = response.Description });
        //        }
        //    }
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}
    }
}
