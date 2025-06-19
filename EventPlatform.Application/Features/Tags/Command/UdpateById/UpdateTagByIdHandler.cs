using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.UdpateById
{
    public class UpdateTagByIdHandler(IActions actions) : IRequestHandler<UpdateTagByIdCommand, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(UpdateTagByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Tag, TagDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
