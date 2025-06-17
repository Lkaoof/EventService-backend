using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.Create
{
    public class CreateTagHandler(IActions actions) : IRequestHandler<CreateTagCommand, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Tag, TagDto>(request, cancellationToken);
        }
    }
}
