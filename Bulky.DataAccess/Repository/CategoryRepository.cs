using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db) : base(db) => _db = db;

    public void Update(Category category) => _db.Categories?.Update(category);

}
