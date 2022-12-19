using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Domain.Enums
{
    public enum StatusCode
    {
        //Product
        ProductNotFound = 11,

        //User
        UserNotFound = 22,

        OK = 200,
        BadRequestError = 400,
        InternalServerError = 500
    }
}
