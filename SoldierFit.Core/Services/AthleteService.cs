namespace SoldierFit.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Infrastructure.Common;
    using SoldierFit.Infrastructure.Data.Models;

    /// <summary>
    /// Service for managing athlete-related operations.
    /// </summary>
    public class AthleteService : IAthleteService
    {
        private readonly IRepository repository;

        public AthleteService(IRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task CreateAsync(
            string firstName,
            string middleName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string userId)
        {
            Athlete athlete = new()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Age = age,
                PhoneNumber = phoneNumber,
                Email = email,
                UserId = userId
            };

            await repository.AddAsync(athlete);
            await repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository
                .AllAsNoTracking<Athlete>()
                .AnyAsync(a => a.UserId == userId);
        }

        /// <inheritdoc/>
        public async Task<bool> UserWithPhoneExistsAlready(string phoneNumber)
        {
            return await repository
                .AllAsNoTracking<Athlete>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        /// <inheritdoc/>
        public async Task<int?> GetAthleteIdAsync(string userId)
        {
            Athlete? athlete = await repository
                .AllAsNoTracking<Athlete>()
                .FirstOrDefaultAsync(a => a.UserId == userId);

            return athlete?.Id;
        }
    }
}
