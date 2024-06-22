namespace SoldierFit.Core.Contracts
{
    public interface IAthleteService
    {
        Task<bool> ExistsByIdAsync(string id);
    }}
