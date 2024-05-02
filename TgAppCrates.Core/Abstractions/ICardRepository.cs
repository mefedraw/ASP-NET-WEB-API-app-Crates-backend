using TgAppCrates.Core.models;
namespace TgAppCrates.Core.Abstractions
{
    public interface ICardRepository
    {
        Task<List<Card>> GetCards(string tgId);
        Task AddCardToUser(string tgId, short type);
        Task Update(Guid id, string tgId, short type, int count);
    }   
}