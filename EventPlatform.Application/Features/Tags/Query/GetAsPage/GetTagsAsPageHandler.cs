using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.GetAsPage
{
    public class GetTagsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTagsAsPageQuery, Page<TagDto>>
    {
        public async Task<Page<TagDto>> Handle(GetTagsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventTags.AsQueryable().PaginateAsync<Tag, TagDto>(request.Page, mapper, cancellationToken);
        }
    }
}
