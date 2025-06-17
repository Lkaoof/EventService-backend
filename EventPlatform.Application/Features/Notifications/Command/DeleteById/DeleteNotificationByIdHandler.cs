using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.DeleteById
{
    public class DeleteNotificationByIdHandler(IActions actions) : IRequestHandler<DeleteNotificationByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Notification>(request.Id, cancellationToken);

        }
    }
}
