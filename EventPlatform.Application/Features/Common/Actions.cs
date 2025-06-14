using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventPlatform.Application.Features.Common
{
    public class Actions(IMapper mapper, IDatabaseContext context) : IActions
    {

        public async Task<Result<M>> Create<T, M, R>(DbSet<T> set, R request, CancellationToken ct = default, Action<T>? entityAction = default) where T : class
        {
            var entity = mapper.Map<T>(request);
            entityAction?.Invoke(entity);
            set.Add(entity);
            var result = await context.SaveChangesAsync(ct);
            return result == 0 ? Result.Failure<M>() : Result.Success(mapper.Map<M>(entity));
        }

        public async Task<Result<M>> Update<T, M, K, R>(DbSet<T> set, K id, R request, CancellationToken ct = default, Action<T>? entityAction = default) where T : class
        {
            var entity = await set.FindAsync(id, ct);

            if (entity == null)
            {
                return Result.Failure<M>($"entity {id} not found");
            }
            mapper.Map(request, entity);

            entityAction?.Invoke(entity);

            await context.SaveChangesAsync(ct);
            return Result.Success(mapper.Map<M>(entity));
        }

        public async Task<Result> DeleteById<T, R>(DbSet<T> set, R Id, CancellationToken ct = default, Action<T>? entityAction = default) where T : class
        {
            var entity = await set.FindAsync(Id, ct);
            if (entity == null) return Result.Failure($"entity {Id} not found", Status.NotFound);
            set.Remove(entity);
            entityAction?.Invoke(entity);
            await context.SaveChangesAsync(ct);
            return Result.Success(status: Status.NoContent);
        }

        public async Task<Result<M>> GetById<T, M, R>(DbSet<T> set, R Id, CancellationToken ct = default, Action<T>? entityAction = default) where T : class
        {
            var entity = await set.FindAsync(Id, ct);
            if (entity == null)
            {
                return Result.Failure<M>(status: Status.NotFound);
            }

            entityAction?.Invoke(entity);

            return Result.Success(mapper.Map<M>(entity));
        }

        public async Task<ICollection<M>> GetAll<T, M>(DbSet<T> set, CancellationToken ct = default) where T : class
        {
            return await set.AsNoTracking().ProjectTo<M>(mapper.ConfigurationProvider).ToListAsync(ct);
        }
    }
}
