using Microsoft.AspNetCore.SignalR;
using StudentManager.Application.Features.Message.DTOs;
using StudentManager.Application.Interfaces;
using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Hubs
{
    public  class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = Context.UserIdentifier; // đảm bảo UserId được gán vào Claims

            //var request = new SendMessageRequest
            //{
            //    ReceiverId = Guid.Parse(receiverId),
            //    Content = message
            //};

            var request = new ChatMessages
            {
                ReceiverId = Guid.Parse(receiverId),
                Content = message,
            };

            await _chatService.SendMessageAsync(request);

            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
        }
    }
}
