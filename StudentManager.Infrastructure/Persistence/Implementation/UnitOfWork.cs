using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using StudentManager.Shared.Exceptions;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _db;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(DBContext db, IUserRepository userRepository)
        {
            _db = db;
            _userRepository = userRepository;
        }

        public IUserRepository Users => _userRepository;

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logging lỗi nếu cần
                throw;
            }
        }
    }
}
