using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.Get
{
    public class GetUsersHandler(IActions actions) : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<User, UserDto>(cancellationToken);
        }
    }
}
