using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.GetAsPage
{
    public class GetEventMoodsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventMoodsAsPageQuery, Page<EventMoodDto>>
    {
        public async Task<Page<EventMoodDto>> Handle(GetEventMoodsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventMoods.ProjectTo<EventMoodDto>(mapper.ConfigurationProvider).AsQueryable().PaginateAsync(request.Page, cancellationToken);
        }
    }
}
