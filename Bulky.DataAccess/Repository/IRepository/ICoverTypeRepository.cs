using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository;
public interface ICoverTypeRepository : IRepository<CoverType>
{
    void Update(CoverType coverType);
}
