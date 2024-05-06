namespace WebApplication1.Contracts
{
    public record GetAllCardsResponse(
        Guid Id,
        string Tg_id,
        short Type,
        int Count,
        string Name,
        string Url);
    
    public record GetRandomCardResponse(
        short Type,
        string Name,
        string Url);
}