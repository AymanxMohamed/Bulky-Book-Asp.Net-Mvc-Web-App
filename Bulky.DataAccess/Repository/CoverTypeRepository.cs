using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;
public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
{
    private readonly AppDbContext _db;
    public CoverTypeRepository(AppDbContext db) : base(db) => _db = db;

    public void Update(CoverType coverType) => _db.CoverTypes?.Update(coverType);

}
