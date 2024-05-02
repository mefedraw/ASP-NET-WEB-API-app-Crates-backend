using TgAppCrates.Core.models;
namespace TgAppCrates.Core.Abstractions
{
    public interface ICardRepository
    {
        Task<List<Card>> GetCards(string tgId);
        Task<Task> addCardToUser(string tgId, short type);
        Task<Task> update(Guid id, string tgId, short type, int count);
    }   
}