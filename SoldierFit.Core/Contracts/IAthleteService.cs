namespace SoldierFit.Core.Contracts
{
    public interface IAthleteService
    {
        Task CreateAsync(
            string firstName,
            string middleName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string userId);

        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserWithPhoneExistsAlready(string phoneNumber);
    }
}
