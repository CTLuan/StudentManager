using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class ChatRepository : IChatRepository
    {
        private readonly DBContext _db;

        public ChatRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddMessageAsync(ChatMessages message)
        {
            await _db.ChatMessages.AddAsync(message);
        }


        public async Task<List<ChatMessages>> GetMessagesBetweenAsync(Guid user1Id, Guid user2Id)
        {
            var result = await _db.ChatMessages
                .Where(m => (m.SenderId == user1Id && m.ReceiverId == user2Id) ||
                            (m.SenderId == user2Id && m.ReceiverId == user1Id))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return result;
        }
    }
}
