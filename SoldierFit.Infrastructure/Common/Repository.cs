namespace SoldierFit.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Infrastructure.Data;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All<T>() where T : class
            => DbSet<T>();

        public IQueryable<T> AllAsNoTracking<T>() where T : class 
            => DbSet<T>().AsNoTracking();

        public async Task AddAsync<T>(T entity) where T : class
            => await DbSet<T>().AddAsync(entity);

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();


        private DbSet<T> DbSet<T>() where T  : class
            => context.Set<T>();
    }
}
