using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Tags
{
    public class TagDto : IMapWith<Tag>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
