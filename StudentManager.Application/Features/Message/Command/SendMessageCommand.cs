using MediatR;
using StudentManager.Application.Features.Message.DTOs;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Message.Command
{
    public class SendMessageCommand : IRequest<ApiResponse<SendMessageResponse>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
