using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ContactModels;

namespace GamesWorkshop.Service.Interfaces
{
	public interface IContactService
	{
		Task<IBaseResponse<Contact>> CreateContact(CreateContactViewModel vm);
	}
}
