namespace SoldierFit.Infrastructure.Common
{
    /// <summary>
    /// Represents a combined repository and unit of work pattern interface.
    /// Provides methods for querying, adding, deleting, and saving entities.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>An IQueryable of T.</returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// Gets all entities of type T without tracking.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>An IQueryable of T without tracking.</returns>
        IQueryable<T> AllAsNoTracking<T>() where T : class;

        /// <summary>
        /// Adds a new entity of type T to the context.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Saves all changes made in the context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Gets an entity of type T by its identifier.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        Task<T?> GetByIdAsync<T>(object id) where T : class;

        /// <summary>
        /// Deletes an entity of type T by its identifier.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        void Delete<T>(T entity) where T : class;
    }
}
