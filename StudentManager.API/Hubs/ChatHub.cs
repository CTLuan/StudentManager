using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StudentManager.Application.Features.Message.Command;
using StudentManager.Domain.Entities;

namespace StudentManager.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendMessage([FromBody] SendMessageCommand command)
        {
            // Gửi command xử lý theo CQRS
            await _mediator.Send(command);

            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
