using GamesWorkshop.Domain.View.ContactModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		[HttpGet]
		public IActionResult GetContact() => View();

		[HttpPost]
		public async Task<IActionResult> GetContact(CreateContactViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var response = await _contactService.CreateContact(vm);
				if (response.StatusCode == Domain.Enums.StatusCode.OK)
				{
					return Json(new { description = response.Description });
				}
			}
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}
