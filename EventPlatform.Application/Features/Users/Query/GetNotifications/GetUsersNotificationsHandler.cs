using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Users.Query.GetNotifications
{
    public class GetUsersNotificationsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersNotificationsQuery, ICollection<UserNotificationDto>>
    {
        public async Task<ICollection<UserNotificationDto>> Handle(GetUsersNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await context.Notifications
                .AsNoTracking()
                .Where(ut => ut.UserId == request.UserId)
                .ProjectTo<UserNotificationDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
