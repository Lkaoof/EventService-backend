using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Command.Create
{
    public class CreateEventHandler(IActions actions) : IRequestHandler<CreateEventCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Event, EventDto>(request, cancellationToken, async (event_, context) =>
            {
                foreach (var tagTitle in request.TagTitles)
                {
                    var tag = await context.EventTags.FirstOrDefaultAsync(t => t.Title == tagTitle);
                    if (tag is null)
                    {
                        tag = new Tag { Title = tagTitle };
                        context.EventTags.Add(tag);
                    }
                    event_.Tags.Add(tag);
                }
            });
        }
    }
}
