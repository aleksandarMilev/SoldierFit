namespace SoldierFit.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllAsNoTracking<T>() where T : class;
    }
}
