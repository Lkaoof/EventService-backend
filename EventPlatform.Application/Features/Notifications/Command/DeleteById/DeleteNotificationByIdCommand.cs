using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.DeleteById
{
    public class DeleteNotificationByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"notification:{Id}", "notifications*"];
    }
}
