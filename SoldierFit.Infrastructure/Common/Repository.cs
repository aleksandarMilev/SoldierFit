namespace SoldierFit.Infrastructure.Common
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Infrastructure.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides an implementation of the IRepository interface using Entity Framework.
    /// Combines repository and unit of work patterns to manage data operations.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IQueryable<T> All<T>() where T : class
            => DbSet<T>();

        /// <inheritdoc/>
        public IQueryable<T> AllAsNoTracking<T>() where T : class
            => DbSet<T>().AsNoTracking();

        /// <inheritdoc/>
        public async Task AddAsync<T>(T entity) where T : class
            => await DbSet<T>().AddAsync(entity);

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        private DbSet<T> DbSet<T>() where T : class
            => context.Set<T>();

        /// <inheritdoc/>
        public async Task<T?> GetByIdAsync<T>(object id) where T : class
            => await DbSet<T>().FindAsync(id);

        /// <inheritdoc/>
        public void Delete<T>(T entity) where T : class
            => DbSet<T>().Remove(entity);
    }
}
