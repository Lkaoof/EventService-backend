using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.Get
{
    public class GetNotificationsHandler(IActions actions) : IRequestHandler<GetNotificationsQuery, ICollection<NotificationDto>>
    {
        public async Task<ICollection<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Notification, NotificationDto>(cancellationToken);
        }
    }
}
