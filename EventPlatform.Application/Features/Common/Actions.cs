using System.Collections.Concurrent;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Common
{
    public class Actions(IMapper mapper, IDatabaseContext context) : IActions
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo?> DbSets = new();

        private DbSet<T> GetDbSet<T>() where T : class
        {
            Type entityType = typeof(T);
            var propertyInfo = DbSets.GetOrAdd(
                entityType,
                t => context.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>))
                );

            return (DbSet<T>)propertyInfo.GetValue(context);
        }

        public async Task<Result<M>> Create<E, M>(object request, CancellationToken ct = default, Action<E>? entityAction = null) where E : class
        {
            var set = GetDbSet<E>();
            var entity = mapper.Map<E>(request);
            entityAction?.Invoke(entity);
            set!.Add(entity);
            var result = await context.SaveChangesAsync(ct);
            return result == 0 ? Result.Failure<M>() : Result.Success(mapper.Map<M>(entity));
        }

        public async Task<Result<M>> GetById<T, M>(object Id, CancellationToken ct = default, Action<T>? entityAction = default) where T : class
        {
            var set = GetDbSet<T>();
            var entity = await set.FindAsync(Id, ct);
            if (entity == null)
            {
                return Result.Failure<M>(status: Status.NotFound);
            }

            entityAction?.Invoke(entity);

            return Result.Success(mapper.Map<M>(entity));
        }

        public async Task<ICollection<M>> GetAll<E, M>(CancellationToken ct = default) where E : class
        {
            var set = GetDbSet<E>();
            return await set.AsNoTracking().ProjectTo<M>(mapper.ConfigurationProvider).ToListAsync(ct);
        }

        public async Task<Result> DeleteById<E>(object Id, CancellationToken ct = default, Action<E>? entityAction = default) where E : class
        {
            var set = GetDbSet<E>();
            var entity = await set.FindAsync(Id, ct);
            if (entity == null) return Result.Failure($"entity {Id} not found", Status.NotFound);
            set.Remove(entity);
            entityAction?.Invoke(entity);
            await context.SaveChangesAsync(ct);
            return Result.Success(status: Status.NoContent);
        }

        public async Task<Result<M>> Update<E, M>(object id, object request, CancellationToken ct = default, Action<E>? entityAction = default) where E : class
        {
            var set = GetDbSet<E>();
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
    }
}
