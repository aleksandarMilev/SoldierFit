namespace SoldierFit.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Infrastructure.Data;

    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All<T>() where T : class 
            => context.Set<T>();

        public IQueryable<T> AllAsNoTracking<T>() where T : class 
            => context.Set<T>().AsNoTracking();
    }
}
