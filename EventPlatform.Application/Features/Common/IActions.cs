using EventPlatform.Application.Common.ResultWrapper;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Common
{
    public interface IActions
    {
        Task<Result<M>> Create<T, M, R>(DbSet<T> set, R request, CancellationToken ct = default, Action<T>? entityAction = null) where T : class;
        Task<Result> DeleteById<T, R>(DbSet<T> set, R Id, CancellationToken ct = default, Action<T>? entityAction = null) where T : class;
        Task<ICollection<M>> GetAll<T, M>(DbSet<T> set, CancellationToken ct = default) where T : class;
        Task<Result<M>> GetById<T, M, R>(DbSet<T> set, R Id, CancellationToken ct = default, Action<T>? entityAction = null) where T : class;
        Task<Result<M>> Update<T, M, K, R>(DbSet<T> set, K id, R request, CancellationToken ct = default, Action<T>? entityAction = null) where T : class;
    }
}