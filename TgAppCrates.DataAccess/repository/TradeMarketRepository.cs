namespace TgAppCrates.DataAccess.repository;

using TgAppCrates.Core.Abstractions;
using TgAppCrates.Core.models;
using TgAppCrates.DataAccess.repository;

public class TradeMarketRepository : ITradeMarketRepository
{
    private readonly AppDbContext _context;
    private readonly ICardRepository _cardRepository;

    public TradeMarketRepository(AppDbContext context, ICardRepository cardRepository)
    {
        _context = context;
        this._cardRepository = cardRepository;
    }

    public async Task PutUpForSale(short type, string tgId, ulong price)
    {
        var cardForSale = _cardRepository.GetCardData(type);
        
    }
}