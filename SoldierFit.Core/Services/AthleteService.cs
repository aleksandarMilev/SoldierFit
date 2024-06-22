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

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository
                .AllAsNoTracking<Athlete>()
                .AnyAsync(a => a.UserId == userId)
        }
    }
}
