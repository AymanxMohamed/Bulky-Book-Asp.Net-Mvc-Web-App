namespace Bulky.DataAccess.Repository.IRepository;
public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    ICoverTypeRepository CoverTypeRepository { get; }
    void Save();
}
