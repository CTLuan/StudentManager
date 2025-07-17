using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Domain.Interfaces;
using StudentManager.Domain.Entities;
using StudentManager.Infrastructure.Persistence.Context;
using StudentManager.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetUserByEmailAddress(string EmailAddress)
        {
            var user = await _db.Users.Where(x => x.EmailAddress == EmailAddress).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserByID(Guid UserID)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserID == UserID);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _db.Users.ToListAsync();
            return result;
        }

        public async Task<bool> UpdateUser(User User)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserID == User.UserID);
            if (user != null)
            {
                _db.Users.Update(user);
                return true;
            }
            return false;
        }
    }
}
