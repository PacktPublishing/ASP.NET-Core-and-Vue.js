using System.Collections.Generic;
using Travel.Domain.Entities;

namespace Travel.WebApi.Auth
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
