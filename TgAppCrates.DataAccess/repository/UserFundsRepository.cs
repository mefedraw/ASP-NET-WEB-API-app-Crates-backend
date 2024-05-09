using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
using TgAppCrates.Core.Abstractions;

namespace TgAppCrates.DataAccess.repository;
public class UserFundsRepository : IUserFundsRepository
{
    private readonly AppDbContext _context;

    public UserFundsRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool UserExists(string tgId)
    {
        return _context.UserFunds.Any(u => u.TgId == tgId);
    }

    public async Task AddFundsToUser(string tgId, ulong fundsAmount)
    {
        var user = _context.UserFunds.SingleOrDefault(u => u.TgId == tgId);
        if (user == null)
        {
            var tempUser = new UserFunds(Guid.NewGuid(), tgId, fundsAmount);
            await _context.UserFunds.AddAsync(tempUser);
            Console.WriteLine("No User at all, UserFunds were added!");
        }
        else
        {
            user.Funds += fundsAmount;
            _context.Update(user);
            Console.WriteLine("Funds were added" + "(" + fundsAmount + ")" + " to user " + tgId);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveFundsFromUser(string tgId, ulong fundsAmount)
    {
        if (!UserExists(tgId)) return false;
        var user = _context.UserFunds.SingleOrDefault(u => u.TgId == tgId);
        if (user.Funds < fundsAmount) return false;
        user.Funds -= fundsAmount;
        _context.Update(user);
        await _context.SaveChangesAsync();
        Console.WriteLine("Funds were removed" + "(" + fundsAmount + ")" + " from user " + tgId);
        return true;
    }

    public ulong GetUserFunds(string tgId)
    {
        var user = _context.UserFunds.Where(u => u.TgId == tgId).SingleOrDefault();
        return user.Funds;
    }
}