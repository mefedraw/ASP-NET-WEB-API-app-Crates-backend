using TgAppCrates.Core.models;
namespace TgAppCrates.Core.Abstractions
{
    public interface ICardRepository
    {
        Task<List<Card>> GetCards(string tgId);
        
        Task<CardData> GetRandomCardAsync(string tg_id);

        CardData GetCardData(short type);

        Task AddCardData(short type, string cardName, string url);
        
        Task AddCardToUserAsync(string tgId, short type);
        Task Update(Guid id, string tgId, short type, int count);
    }   
}