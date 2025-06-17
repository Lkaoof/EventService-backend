using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.GetById
{
    public class GetNotificationByIdHandler(IActions actions) : IRequestHandler<GetNotificationByIdQuery, Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Notification, NotificationDto>(request.Id, cancellationToken);
        }
    }
}
