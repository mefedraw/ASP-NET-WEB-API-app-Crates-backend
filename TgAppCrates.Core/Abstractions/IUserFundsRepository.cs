namespace TgAppCrates.Core.Abstractions;

using TgAppCrates.Core.models;

public interface IUserFundsRepository
{
    Task AddFundsToUser(string tgId, ulong fundsAmount);
    
    Task<bool> RemoveFundsFromUser(string tgId, ulong fundsAmount);
}