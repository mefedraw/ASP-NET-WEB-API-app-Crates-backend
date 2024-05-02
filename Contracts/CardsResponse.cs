namespace WebApplication1.Contracts
{
    public record CardsResponse(
        Guid Id,
        string Tg_id,
        short Type,
        int Count);   
}