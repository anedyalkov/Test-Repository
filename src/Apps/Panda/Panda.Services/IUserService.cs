using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services
{
    public interface IUserService
    {
        User CreateUser(string username, string password, string email);

        User GetUserByUsernameAndPassword(string username, string password);

        List<string> GetUsernames();
    }
}
