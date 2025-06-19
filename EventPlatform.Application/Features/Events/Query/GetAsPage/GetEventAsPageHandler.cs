using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetAsPage
{
    public class GetEventAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventAsPageQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetEventAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Events.ProjectTo<EventDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
