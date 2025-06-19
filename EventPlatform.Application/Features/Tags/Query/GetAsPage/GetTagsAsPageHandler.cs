using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.GetAsPage
{
    public class GetTagsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTagsAsPageQuery, Page<TagDto>>
    {
        public async Task<Page<TagDto>> Handle(GetTagsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventTags.ProjectTo<TagDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
