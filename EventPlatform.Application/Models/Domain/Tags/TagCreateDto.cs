using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Tags
{
    public class TagCreateDto : IMapWith<Tag>
    {
        public string Title { get; set; }
    }
}
