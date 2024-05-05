using TgAppCrates.Core.models;
namespace TgAppCrates.Core.Abstractions
{
    public interface ICardRepository
    {
        Task<List<Card>> GetCards(string tgId);

        CardData GetCardData(short type);

        Task AddCardData(short type, string cardName, string url);
        
        Task AddCardToUser(string tgId, short type);
        Task Update(Guid id, string tgId, short type, int count);
    }   
}