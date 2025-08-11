using MediatR;
using StudentManager.Application.Features.Message.DTOs;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Message.Command
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, ApiResponse<SendMessageResponse>>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SendMessageCommandHandler(IChatRepository chatRepository, IUnitOfWork unitOfWork)
        {
            _chatRepository = chatRepository ?? throw new ArgumentNullException(nameof(chatRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ApiResponse<SendMessageResponse>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var message = new ChatMessages
                {
                    Id = Guid.NewGuid(),
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Content = request.Content,
                    SentAt = DateTime.UtcNow
                };

                var isMessageSent = _chatRepository.AddMessageAsync(message);
                await _unitOfWork.SaveChangesAsync();

                var response = new SendMessageResponse
                {
                    MessageId = message.Id,
                    SenderId = message.SenderId,
                    ReceiverId = message.ReceiverId,
                    Content = message.Content,
                    SentAt = message.SentAt
                };
                return ApiResponse<SendMessageResponse>.SuccessResponse(response, "Message sent successfully.");
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
    }
}
