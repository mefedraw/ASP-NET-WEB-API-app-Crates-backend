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

    public async Task AddCardData(short type, string cardName, string url)
    {
        var cardsWithSuchType = _context.CardsData.Where(u => u.Type == type).ToList();
        var cardsWithSuchCardName = _context.CardsData.Where(u => u.CardName == cardName).ToList();
        if (cardsWithSuchType.Count == 0 && cardsWithSuchCardName.Count == 0)
        {
            var tempCard = new CardData(Guid.NewGuid(), type, cardName, url);
            await _context.CardsData.AddAsync(tempCard);
            Console.WriteLine("No CardData at all, cardData were added!");
        }

        await _context.SaveChangesAsync();
    }

    public async Task<CardData> GetRandomCardAsync(string tg_id)
    {
        Random rnd = new Random();
        var tempMaxSize = _context.CardsData.Count();
        short maxSize = (short)tempMaxSize;
        int tempRandomCard = rnd.Next(1, maxSize + 1);
        short randomCard = (short)tempRandomCard;
        await AddCardToUserAsync(tg_id, randomCard);
        return GetCardData(randomCard);
    }

    public CardData GetCardData(short type)
    {
        var cardData = _context.CardsData.Where(c => c.Type == type).FirstOrDefault();
        return cardData;
    }

    public Task<List<Card>> GetCards(string tgId)
    {
        var userCards = _context.Cards.Where(u => u.TgId == tgId).ToList();
        return Task.FromResult(userCards);
    }

    public async Task AddCardToUserAsync(string tgId, short type)
    {
        var userCards = _context.Cards.Where(u => u.TgId == tgId).ToList();
        if (userCards.Count == 0)
        {
            //var tempUser = new Card { Id = Guid.NewGuid(), TgId = tgId, Type = type, Count = 1 };
            var tempUser = new Card(Guid.NewGuid(), tgId, type, 1);
            await _context.Cards.AddAsync(tempUser);
            Console.WriteLine("No user at all, card were added!");
        }
        else
        {
            var card = userCards.SingleOrDefault(x => x.Type == type);
            if (card == null)
            {
                //var tempUser = new Card { Id = Guid.NewGuid(), TgId = tgId, Type = type, Count = 1 };
                var tempUser = new Card(Guid.NewGuid(), tgId, type, 1);
                await _context.Cards.AddAsync(tempUser);
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
    }

    public async Task Update(Guid id, string tgId, short type, int count)
    {
        await _context.Cards.Where(c => c.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(b => b.TgId, b => tgId)
            .SetProperty(b => b.Type, b => type)
            .SetProperty(b => b.Count, b => count));
    }
}