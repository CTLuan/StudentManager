using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Features.User.Queries;
using StudentManager.Application.Features.Users.Queries;

namespace StudentManager.API.GraphQL.Queries
{
    public class Query
    {
        public async Task<UserDto> GetUserByIdAsync(
        Guid id,
        [Service] ISender mediator) =>
        await mediator.Send(new GetUserByIdQuery(id));

        public async Task<List<UserDto>> GetAllUsersAsync(
            [Service] ISender mediator) =>
            await mediator.Send(new GetUsersQuery());

        public string Hello() => "world";

        public string Test() => "world";


    }
}
