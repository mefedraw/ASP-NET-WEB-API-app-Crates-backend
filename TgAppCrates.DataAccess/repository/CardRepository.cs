using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
using TgAppCrates.Core.Abstractions;

namespace TgAppCrates.DataAccess.repository;

public class CardRepository : ICardRepository
{
    private readonly CardsDbContext _context;

    public CardRepository(CardsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Card>> GetCards(string tgId)
    {
        var userCards = _context.Cards.Where(u => u.TgId == tgId).ToList();
        return userCards;
    }
    
    public async  Task<Task> addCardToUser(string tgId, short type)
    {
        var userCards = _context.Cards.Where(u => u.TgId == tgId).ToList();
        if (userCards.Count == 0)
        {
            //var tempUser = new Card { Id = Guid.NewGuid(), TgId = tgId, Type = type, Count = 1 };
            var tempUser = new Card( Guid.NewGuid(),  tgId, type, 1 );
            _context.Cards.AddAsync(tempUser);
            Console.WriteLine("No user at all, card were added!");
        }
        else
        {
            var card = userCards.SingleOrDefault(x => x.Type == type);
            if (card == null)
            {
                //var tempUser = new Card { Id = Guid.NewGuid(), TgId = tgId, Type = type, Count = 1 };
                var tempUser = new Card( Guid.NewGuid(),  tgId, type, 1 );
                _context.Cards.AddAsync(tempUser);
                Console.WriteLine("user exists but not such type, type added!");
            }
            else
            {
                card.Count++;
                _context.Cards.Update(card);
                Console.WriteLine("user exists and type exists, count increased!");
            }
        }

        await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public async Task<Task> update(Guid id, string tgId, short type, int count)
    {
        await _context.Cards.Where(c => c.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(b => b.TgId, b => tgId)
            .SetProperty(b => b.Type, b => type)
            .SetProperty(b => b.Count, b => count));
        return Task.CompletedTask;
    }
    
}