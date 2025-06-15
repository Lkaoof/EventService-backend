using EventPlatform.Application.Common.ResultWrapper;

namespace EventPlatform.Application.Features.Common
{
    public interface IActions
    {
        Task<Result<M>> Create<E, M>(object request, CancellationToken ct = default, Action<E>? entityAction = null) where E : class;
        Task<Result> DeleteById<E>(object Id, CancellationToken ct = default, Action<E>? entityAction = null) where E : class;
        Task<ICollection<M>> GetAll<E, M>(CancellationToken ct = default) where E : class;
        Task<Result<M>> GetById<T, M>(object Id, CancellationToken ct = default, Action<T>? entityAction = null) where T : class;
        Task<Result<M>> Update<E, M>(object id, object request, CancellationToken ct = default, Action<E>? entityAction = null) where E : class;
    }
}