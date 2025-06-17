using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.GetById
{
    public class GetTagByIdHandler(IActions actions) : IRequestHandler<GetTagByIdQuery, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Tag, TagDto>(request.Id, cancellationToken);
        }
    }
}
