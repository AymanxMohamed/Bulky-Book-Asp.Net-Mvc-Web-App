
using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    internal DbSet<T> DbSet;

    public Repository(AppDbContext db) => DbSet = db.Set<T>();
 
    public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> queryable = DbSet;

        queryable = queryable.Where(filter);

        return queryable.FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> queryable = DbSet;

        return queryable.ToList();
    }

    public void Add(T entity) => DbSet.Add(entity);

    public void Remove(T entity) => DbSet.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => DbSet.RemoveRange(entities);

}
