namespace SoldierFit.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Infrastructure.Common;
    using SoldierFit.Infrastructure.Data.Models;
    using System.Threading.Tasks;

    public class AthleteService : IAthleteService
    {
        private readonly IRepository repository;

        public AthleteService(IRepository repository)
        {
            this.repository = repository;
        }

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

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository
                .AllAsNoTracking<Athlete>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserWithPhoneExistsAlready(string phoneNumber)
        {
            return await repository
                .AllAsNoTracking<Athlete>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        } 
    }
}
