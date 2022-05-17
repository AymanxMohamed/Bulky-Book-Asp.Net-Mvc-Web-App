using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    public ICategoryRepository CategoryRepository { get; }

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        CategoryRepository = new CategoryRepository(_db);
    }

    public void Save() => _db.SaveChanges();
}
