using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Commnon;

namespace EventPlatform.Application.Features.Common
{
    public interface IActions
    {
        Task<Result<M>> Create<E, M>(object request, CancellationToken ct = default, Func<E, IDatabaseContext, Task>? entityAction = null) where E : BaseEntity;
        Task<Result> DeleteById<E>(Guid Id, CancellationToken ct = default, Action<E>? entityAction = null) where E : BaseEntity;
        Task<ICollection<M>> GetAll<E, M>(CancellationToken ct = default) where E : BaseEntity;
        Task<Result<M>> GetById<T, M>(Guid id, CancellationToken ct = default, Action<T>? entityAction = null) where T : BaseEntity;
        Task<Result<M>> Update<E, M>(Guid id, object request, CancellationToken ct = default, Action<E>? entityAction = null) where E : BaseEntity;
    }
}