using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.Get
{
    public class GetTagsHandler(IActions actions) : IRequestHandler<GetTagsQuery, ICollection<TagDto>>
    {
        public async Task<ICollection<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Tag, TagDto>(cancellationToken);
        }
    }
}
