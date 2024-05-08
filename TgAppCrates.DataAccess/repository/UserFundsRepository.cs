using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
using TgAppCrates.Core.Abstractions;

namespace TgAppCrates.DataAccess.repository;

public class UserFundsRepository : IUserFundsRepository
{
    private readonly DbContext _context;

    public UserFundsRepository(DbContext context)
    {
        _context = context;
    }

    public bool UserExists(string tgId)
    {
        return _context.UserFunds.Where(u => u.TgId == tgId).Count() > 0;
    }

    public async Task AddFundsToUser(string tgId, ulong fundsAmount)
    {
        if (UserExists(tgId))
        {
            var tempUser = new UserFunds(Guid.NewGuid(), tgId, fundsAmount);
            await _context.UserFunds.AddAsync(tempUser);
            Console.WriteLine("No User at all, UserFunds were added!");
        }
        else
        {
            var user = _context.UserFunds.Where(u => u.TgId == tgId).SingleOrDefault();
            user.Funds += fundsAmount;
            _context.Update(user);
            Console.WriteLine("Funds were added" + "(" + fundsAmount + ")" + " from user " + tgId);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveFundsFromUser(string tgId, ulong fundsAmount)
    {
        if (UserExists(tgId))
        {
            var user = _context.UserFunds.Where(u => u.TgId == tgId).SingleOrDefault();
            if (user.Funds >= fundsAmount)
            {
                user.Funds -= fundsAmount;
                _context.Update(user);
                await _context.SaveChangesAsync();
                Console.WriteLine("Funds were removed" + "(" + fundsAmount + ")" + " from user " + tgId);
                return true;
            }
        }

        return false;
    }

    public ulong GetUserFunds(string tgId)
    {
        var user = _context.UserFunds.Where(u => u.TgId == tgId).SingleOrDefault();
        return user.Funds;
    }
}