using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Domain.Interfaces;
using StudentManager.Domain.Entities;
using StudentManager.Infrastructure.Persistence.Context;
using StudentManager.Shared.Exceptions;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _db;

        public UserRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<bool> CreateUser(User Request)
        {
            try
            {
                Request.UserID = Guid.NewGuid();
                await _db.Users.AddAsync(Request);
                return true;
            }
            catch (Exception ex)
            {
                throw ErrorCatalog.BadRequest;
                throw new NotImplementedException();
            }

        }

        public Task<User> GetUserByID(Guid UserID)
        {
            var result = new User()
            {
                UserID = Guid.NewGuid(),
                UserName = "TestUser",
                EmailAddress = "usertest@gmail.com"
            };

            return Task.FromResult(result);
        }
    }
}
