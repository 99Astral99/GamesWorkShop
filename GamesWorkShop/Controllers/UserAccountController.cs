using GamesWorkshop.Domain.View.ProfileModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesWorkshop.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountProfleService;
        public UserAccountController(IUserAccountService userAccountProfleService)
        {
            _userAccountProfleService = userAccountProfleService;
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var userId = int.Parse(User.FindFirstValue("UserId"));
            var response = await _userAccountProfleService.GetProfile(userId);
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
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
