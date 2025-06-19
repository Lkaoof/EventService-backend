using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.GetAsPage
{
    public class GetNotificationsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetNotificationsAsPageQuery, Page<NotificationDto>>
    {
        public async Task<Page<NotificationDto>> Handle(GetNotificationsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Notifications.ProjectTo<NotificationDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
