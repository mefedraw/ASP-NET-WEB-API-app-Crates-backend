namespace TgAppCrates.Core.Abstractions
{
    public interface IUserFundsRepository
    {
        Task AddFundsToUser(string tgId, ulong fundsAmount);

        Task<bool> RemoveFundsFromUser(string tgId, ulong fundsAmount);

        ulong GetUserFunds(string tgId);

        bool UserExists(string tgId);
    }
}