using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Panda.Data;
using Panda.Data.Models;

namespace Panda.Services
{
    public class UserService : IUserService
    {
        private readonly PandaDbContext db;

        public UserService(PandaDbContext db)
        {
            this.db = db;
        }
        public User CreateUser(string username,string email, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = db.Users
                .FirstOrDefault(u => (u.Username == username || u.Email == username)
                                                              && u.Password == hashedPassword);

            return user;
        }

        public List<string> GetUsernames()
        {
            var users = db.Users.Select(u => u.Username).ToList();
            return users;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
