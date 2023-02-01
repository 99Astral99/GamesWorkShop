using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ContactModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
	public class ContactService : IContactService
	{
		private readonly IBaseRepository<Contact> _contactRepository;
		private readonly IBaseRepository<User> _userRepository;
		public ContactService(IBaseRepository<Contact> contactRepository, IBaseRepository<User> userRepository)
		{
			_contactRepository = contactRepository;
			_userRepository = userRepository;
		}
		public async Task<IBaseResponse<Contact>> CreateContact(CreateContactViewModel vm)
		{
			try
			{
				var user = await _userRepository
					.GetAll()
					.Where(i => i.Email == vm.Email)
					.FirstOrDefaultAsync();

				if (user == null)
				{
					return new BaseResponse<Contact>()
					{
						Description = "User not found",
						StatusCode = Domain.Enums.StatusCode.UserNotFound
					};
				}

				var contact = new Contact()
				{
					UserId = user.Id,
					Message = vm.Message,
					Subject = vm.Subject,
					Email = vm.Email,
				};

				await _contactRepository.Create(contact);

				return new BaseResponse<Contact>()
				{
					Description = "The message has been sent",
					StatusCode = Domain.Enums.StatusCode.OK
				};

			}
			catch (Exception ex)
			{
				return new BaseResponse<Contact>()
				{
					Description = $"[CreateContact]: {ex.Message}",
					StatusCode = Domain.Enums.StatusCode.InternalServerError
				};
			}
		}
	}
}
